
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        //sets the touched objects position to the teleport points poisition
        other.transform.position = teleportPoint.position;
    }
}
