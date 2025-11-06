using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Shawn Evans
/// 11.06.2025
/// Handles behavior of collectible gun upgrade
/// </summary>
public class HeavyPickup : MonoBehaviour
{
    public GameObject gun;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerControllerM>())
        {
            print("test collision with player");
            gun.GetComponent<GunScript>().gunUpgrade = true;
            Destroy(gameObject);
        }
    }
}
