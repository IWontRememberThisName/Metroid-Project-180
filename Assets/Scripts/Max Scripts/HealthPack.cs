using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik, 11/11/25
/// </summary>
public class HealthPack : MonoBehaviour
{
    /// <summary>
    /// Code Allows the player to pick up the items and have the item effects do special things in the game, like jump or gain health. 
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter(Collider other)
    {
        PlayerControllerM player = other.GetComponent<PlayerControllerM>();
        if (player != null)
        {
            player.HealthPack();
            Destroy(gameObject);
        }
    }
}
