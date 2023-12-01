using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{

    //TODO Detecter les points
    public Vector3[] vertices;

    private Mesh mesh;
    private MeshFilter meshFilter;
    private MeshCollider meshCollider;

    void Start()
    {
        // Get the mesh components
        meshFilter = this.GetComponent<MeshFilter>();
        meshCollider = this.GetComponent<MeshCollider>();

        // Create the new mesh
        CreateMesh();
    }

    private void CreateMesh()
    {
        // Create the mesh
        mesh = new Mesh();
        ClockwiseVerticesSort();
        mesh.vertices = vertices;
        Vector2[] uvs = new Vector2[vertices.Length];
        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z);
        }
        mesh.uv = uvs;

        // Polygon triangulation by ear clipping algorithm
        List<int> verticesIndices = new List<int>();
        for (int i = 0; i < vertices.Length; i++)
        {
            verticesIndices.Add(i);
        }
        List<int> triangles = new List<int>();

        int current = 0;
        while (verticesIndices.Count >= 3)
        {
            int previous = (current - 1 + verticesIndices.Count) % verticesIndices.Count;
            int next = (current + 1) % verticesIndices.Count;

            if (IsEar(previous, current, next, verticesIndices))
            {
                triangles.Add(verticesIndices[previous]);
                triangles.Add(verticesIndices[current]);
                triangles.Add(verticesIndices[next]);

                verticesIndices.RemoveAt(current);
                current = 0;
            }
            else
            {
                current = next;
            }
        }

        // Assign the triangles to the mesh
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();

        // Assign the mesh to the filter and collider
        meshFilter.mesh = mesh;
        meshCollider.sharedMesh = mesh;
    }

    private bool IsEar(int previous, int current, int next, List<int> verticesIndices)
    {
        Vector3 previousVector = vertices[verticesIndices[previous]];
        Vector3 currentVector = vertices[verticesIndices[current]];
        Vector3 nextVector = vertices[verticesIndices[next]];

        if(!IsConvex(previousVector, currentVector, nextVector))
        {
            return false;
        }

        for (int j = 0; j < verticesIndices.Count; j++)
        {
            if (j != previous && j != current && j != next)
            {
                if (IsInTriangle(vertices[verticesIndices[j]], previousVector, currentVector, nextVector))
                {
                    return false;
                }
            }
        }

        return true;
    }

    private bool IsConvex(Vector3 previous, Vector3 current, Vector3 next)
    {
        Vector3 v1 = current - previous;
        Vector3 v2 = next - current;
        Vector3 cross = Vector3.Cross(v1, v2);
        return cross.z >= 0;
    }

    private bool IsInTriangle(Vector3 point, Vector3 a, Vector3 b, Vector3 c)
    {
        // Compute vectors
        Vector3 v0 = c - a;
        Vector3 v1 = b - a;
        Vector3 v2 = point - a;

        // Compute dot products
        float dot00 = Vector3.Dot(v0, v0);
        float dot01 = Vector3.Dot(v0, v1);
        float dot02 = Vector3.Dot(v0, v2);
        float dot11 = Vector3.Dot(v1, v1);
        float dot12 = Vector3.Dot(v1, v2);

        // Compute barycentric coordinates
        float invDenom = 1 / (dot00 * dot11 - dot01 * dot01);
        float u = (dot11 * dot02 - dot01 * dot12) * invDenom;
        float v = (dot00 * dot12 - dot01 * dot02) * invDenom;

        // Check if point is in triangle
        return (u >= 0) && (v >= 0) && (u + v < 1);
    }

    private void ClockwiseVerticesSort()
    {
        Vector3 center = Vector3.zero;
        foreach (Vector3 vertex in vertices)
        {
            center += vertex;
        }
        center /= vertices.Length;

        List<Vector3> sortedVertices = new List<Vector3>(vertices);
        for (int i = 0; i < sortedVertices.Count; i++)
        {
            sortedVertices[i] -= center;
        }

        sortedVertices.Sort((a, b) => Mathf.Atan2(a.x, a.z).CompareTo(Mathf.Atan2(b.x, b.z)));

        for (int i = 0; i < sortedVertices.Count; i++)
        {
            sortedVertices[i] += center;
        }

        vertices = sortedVertices.ToArray();
    }
}
