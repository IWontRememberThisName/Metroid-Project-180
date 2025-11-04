using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik, 11/1/25, Handles the special enemy coding
/// </summary>

public class EnemyS : MonoBehaviour
{
    public int Health = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamageH() // Damage for the special enemy called with each bullet 
    {
        Health -= 3;
        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
    public void DamageE() // damage for the special enemy called with each bullet
    {
        Health--;
        if (Health < 0)
        {
            Destroy(gameObject);
        }
    }
}
