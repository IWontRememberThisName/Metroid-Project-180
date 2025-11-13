using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik, 11/11/25
/// </summary>
public class HealthPack : MonoBehaviour
{

    public int HealthPackNum =15;
    /// <summary>
    /// Code Allows the player to pick up the items and have the item effects do special things in the game, like jump or gain health. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        PlayerControllerM player = collision.gameObject.GetComponent<PlayerControllerM>(); // allows the use for calling Healthpack
        if (player != null) // if the player colides with the healthpack
        {
            if((player.health > 99 && player.maxHealthIncreased == false) || (player.health > 100 && player.maxHealthIncreased == true))
            {
                player.HealthPack();
            }
            Destroy(gameObject);

        }
    }
}
