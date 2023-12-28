using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TerrainObserverEventHandler : DefaultObserverEventHandler
{
    private GameObject terrain;
    private GameObject player;
    private Rigidbody playerRigidbody;

     protected override void Start()
    {
        base.Start();

        terrain = GameObject.Find("Terrain");
        player = GameObject.Find("Player");
        playerRigidbody = player.GetComponent<Rigidbody>();
    }

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();

        // Set player rigidbody IsKinematic to false
        playerRigidbody.isKinematic = false;
    }
}
