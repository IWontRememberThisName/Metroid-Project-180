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
    public bool goingLeft;
    public bool cooldown = false;
    public float cooldownTime = 2f;
    //Variable storing the bullet prefab
    public GameObject projectilePrefab;


    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    /// <summary>
    /// Fires a bullet when the space bar is pressed if the cooldown bool is false
    /// </summary>
    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && cooldown == false)
        {
            SpawnProjectile();
            //cooldown is set to true and the coroutine begins immediately after which sets it back to false
            cooldown = true;
            StartCoroutine(Recharge());
        }
        
    }

    /// <summary>
    /// Spawn a bullet at the position of the gun
    /// </summary>
    private void SpawnProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        if (projectile.GetComponent<BulletM>())
        {
            projectile.GetComponent<BulletM>().goingleft = goingLeft;
        }

    }

    /// <summary>
    /// Coroutine that delays the cooldown flag being set to true
    /// </summary>
    /// <returns></returns>
    private IEnumerator Recharge()
    {
        yield return new WaitForSeconds(cooldownTime);
        cooldown = false;
    }
}
