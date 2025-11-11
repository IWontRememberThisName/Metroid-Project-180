using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPowerUp : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Check if player collided with this object
        if (collision.gameObject.GetComponent<PlayerControllerM>())
        {
            collision.gameObject.GetComponent<PlayerControllerM>().AddJump();
        }
    }
}x
