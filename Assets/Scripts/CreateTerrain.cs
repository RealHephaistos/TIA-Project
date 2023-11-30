using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTerrain : MonoBehaviour
{

    //TODO Detecter les points
    public Vector3[] vertices;

    private Mesh mesh;
    private MeshFilter filter;
    private MeshCollider collider;
    private MeshRenderer renderer;

    void Start()
    {
        // Get the mesh components
        filter = this.GetComponent<MeshFilter>();
        collider = this.GetComponent<MeshCollider>();
        renderer = this.GetComponent<MeshRenderer>();

        // Create the new mesh
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
