using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik 11/11/25, Code is for the JumpPowerUp pickup, relativly simple
/// </summary>
public class JumpPowerUp : MonoBehaviour
{   
    /// <summary>
     /// Code Allows the player to pick up the items and have the item effects do special things in the game, like jump or gain health. 
     /// </summary>
     /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        //Check if player collided with this object
        if (collision.gameObject.GetComponent<PlayerControllerM>())
        {
            collision.gameObject.GetComponent<PlayerControllerM>().AddJump();
            Destroy(gameObject);
        }
    }
}
