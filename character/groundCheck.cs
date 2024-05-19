using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundCheck : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != player.gameObject)
        {
            player.isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject != player.gameObject)
        {
            player.isGrounded = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject != player.gameObject)
        {
            player.isGrounded = true;
        }
    }
}
