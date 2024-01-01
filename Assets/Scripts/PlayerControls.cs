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

    private Camera mainCamera;

    [SerializeField] private GameObject playerSpawn;

    // True if the start game button has been pressed
    private bool isGameRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        leanJoystickScript = leanJoystick.GetComponent<LeanJoystick>();
        rb = GetComponent<Rigidbody>();

        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            // Add force to the player in the direction of the joystick
            Vector3 movement = new Vector3(leanJoystickScript.ScaledValue.x, 0, leanJoystickScript.ScaledValue.y);
            // Ajust the movement vector relative to the camera
            movement = mainCamera.transform.TransformDirection(movement);
            rb.AddForce(movement * moveSpeed);

            // Apply friction to the player
            rb.velocity *= friction;
            rb.angularVelocity *= friction;
        }
    }

    public void OnTerrainFound()
    {
        if(isGameRunning)
        {
            // Enable the joystick
            leanJoystick.SetActive(true);

            // Enable the player
            this.gameObject.SetActive(true);

            // Set the player kinematic to false
            rb.isKinematic = false;
        }
        
    }

    public void OnTerrainLost()
    {
        if(isGameRunning)
        {
            // Disable the joystick
            leanJoystick.SetActive(false);

            // Disable the player
            this.gameObject.SetActive(false);

            // Set the player kinematic to true
            rb.isKinematic = true;
        }
    }

    public void SetGameState(bool state)
    {
        isGameRunning = state;
    }

    public void ResetPlayer()
    {
        // Reset the player position
        this.transform.position = playerSpawn.transform.position;
        SetGameState(true);
        this.gameObject.SetActive(true);
    }
}
