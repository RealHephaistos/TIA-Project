using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnOnTouch : MonoBehaviour
{

    [SerializeField] private GameObject player;
    private PlayerControls playerControls;

    private void Start()
    {
        playerControls = player.GetComponent<PlayerControls>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerControls.ResetPlayer();
        }
    }
}
