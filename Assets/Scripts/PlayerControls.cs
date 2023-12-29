using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GameObject leanJoystick;
    private LeanJoystick leanJoystickScript;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float friction;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        leanJoystickScript = leanJoystick.GetComponent<LeanJoystick>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Add force to the player in the direction of the joystick
        Vector3 movement = new Vector3(leanJoystickScript.ScaledValue.x, 0, leanJoystickScript.ScaledValue.y);
        // Ajust the movement vector relative to the camera
        movement = Camera.main.transform.TransformDirection(movement);
        rb.AddForce(movement * moveSpeed);

        // Apply friction to the player
        rb.velocity *= friction;
        rb.angularVelocity *= friction;
    }
}
