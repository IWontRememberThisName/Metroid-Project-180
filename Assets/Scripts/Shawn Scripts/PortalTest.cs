using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTest : MonoBehaviour
{
    public Transform teleportPoint;
    //sdfjsdlkf

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerControllerM>())
        {
            other.transform.position = teleportPoint.position;
        }
    }
}
