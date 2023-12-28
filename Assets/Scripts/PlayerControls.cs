using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GameObject leanJoystick;
    private LeanJoystick leanJoystickScript;
    [SerializeField] private float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        leanJoystickScript = leanJoystick.GetComponent<LeanJoystick>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveVector = leanJoystickScript.ScaledValue;
        Vector3 moveDirection = new Vector3(moveVector.x, 0, moveVector.y);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
