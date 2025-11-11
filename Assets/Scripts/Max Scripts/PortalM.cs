
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControllerM>())
        {
            other.transform.position = teleportPoint.position;
        }
    }
}
