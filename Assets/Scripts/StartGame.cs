using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject terrain;
    [SerializeField] private GameObject joystick;
    [SerializeField] private GameObject errorTextGameobject;

    private PlayerControls playerControls;
    private Collider terrainCollider;
    private TextMeshProUGUI errorText;

    private void Start()
    {
        playerControls = player.GetComponent<PlayerControls>();
        errorText = errorTextGameobject.GetComponent<TextMeshProUGUI>();
        terrainCollider = terrain.GetComponent<Collider>();
    }

    public void SetPlayer()
    {
        if (!terrainCollider.enabled)
        {
            errorText.text = "Error : Terrain is not active";
        }
        else
        {
            playerControls.ResetPlayer();
            joystick.SetActive(true);
            this.gameObject.SetActive(false);
            errorText.text = "";
        }
    }
}
