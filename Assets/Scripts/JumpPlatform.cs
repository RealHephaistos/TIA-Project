using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlatform : MonoBehaviour
{
    [SerializeField] private GameObject jumpButton;
    [SerializeField] private float jumpForce;

    private LeanButtonRelease jumpButtonScript;
    private float currentCharge = 0;

    // Start is called before the first frame update
    void Start()
    {
        jumpButtonScript.OnDown.AddListener(Charge);
        jumpButtonScript.OnRelease.AddListener(Jump);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Charge()
    {
        
    }

    private void Jump()
    {
        currentCharge = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // Enable the jump button
            jumpButton.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Disable the jump button
            jumpButton.SetActive(false);
            currentCharge = 0;
        }
    }
}
