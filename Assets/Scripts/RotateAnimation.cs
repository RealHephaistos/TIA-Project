using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAnimation : MonoBehaviour
{
    [SerializeField] private float rotateSpeedX;
    [SerializeField] private float rotateSpeedY;
    [SerializeField] private float rotateSpeedZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateSpeedX * Time.deltaTime, rotateSpeedY * Time.deltaTime, rotateSpeedZ * Time.deltaTime);
    }
}
