using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyLeaf : MonoBehaviour
{
    public float bounceHeight = 10;
    private float originalJumpHeight;
    private Rigidbody rb;
    private PlayerController playerController;
    public GameObject player;
    public bool scaleWithHeight;

    private void Awake()
    {
        rb = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
        
    }
    private void Start()
    {
        //storing original jump height
        originalJumpHeight = playerController.jumpHeight;
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //bouncing the player
        if (collision.gameObject == player && collision.relativeVelocity.y < 0)
        {
            playerController.jumpHeight = bounceHeight;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // resetting player controller
        if (collision.gameObject == player)
        {
            playerController.jumpHeight = originalJumpHeight;
        }
    }


}
