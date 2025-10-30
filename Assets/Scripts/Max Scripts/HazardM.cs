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
    private void OnCollisionEnter(Collision collision)
    {
        //Check if player collided with this object
        if (collision.gameObject.GetComponent<PlayerControllerM>())
        {
            //Respawn the player
            collision.gameObject.GetComponent<PlayerControllerM>().Respawn();
        }
    }

    private IEnumerator IFrames()
    {
        yield return new WaitForSeconds(damagedStateDuration);

    }
}
