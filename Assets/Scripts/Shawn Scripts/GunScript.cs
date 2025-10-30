using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Shawn Evans
 * 10/30/2025
 * Handles the controls and behavior of the gun
 */
public class GunScript : MonoBehaviour
{
    //Variable storing the bullet prefab
    public GameObject projectilePrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    /// <summary>
    /// Fires a bullet when the space bar is pressed
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
    }

    /// <summary>
    /// Spawn a bullet at the position of the gun
    /// </summary>
    private void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

    }
}
