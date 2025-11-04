using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Shawn Evans 
 * 10.21.2025
 * Handles detecting and damaging the player
 */

public class HazardM : MonoBehaviour
{
    public float damagedStateDuration = 5f;
    public int damageVal = 15;
    private void OnCollisionEnter(Collision collision)
    {
        //Check if player collided with this object
        if (collision.gameObject.GetComponent<PlayerControllerM>())
        {
            //if the player is not in the invincible state from taking damage
            if(collision.gameObject.GetComponent<PlayerControllerM>().isDamaged == false)
            {
                //Decreases health by the damageVal and turns on the invincibility state
                collision.gameObject.GetComponent<PlayerControllerM>().health -= damageVal;
                collision.gameObject.GetComponent<PlayerControllerM>().Respawn();
            }
        }
    }
}
