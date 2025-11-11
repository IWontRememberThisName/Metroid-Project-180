using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik 11/11/25, adds and mantians health for the player by calling the script in the controler. 
/// </summary>
public class ExtraHealth : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Check if player collided with this object
        if (collision.gameObject.GetComponent<PlayerControllerM>())
        {
            collision.gameObject.GetComponent<PlayerControllerM>().ExtraHealth();
        }
    }
}
