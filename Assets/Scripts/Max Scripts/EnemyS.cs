using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik, 11/1/25, Handles the special enemy coding
/// </summary>

public class EnemyS : MonoBehaviour
{

    public float Speed = 8f;
    public Transform LeftPoint;
    public Transform RightPoint;
    private Vector3 direction;
    private Vector3 startLeftPos;
    private Vector3 startRightPos;
    public int Health = 5;
    private Rigidbody RB;
    public float jumpForce = 8f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += direction * Speed * Time.deltaTime;
        if (transform.position.x <= startLeftPos.x)
        {
            direction = Vector3.right;
        }
        else if (transform.position.x >= startRightPos.x)
        {
            direction = Vector3.left;
        }

    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f))
            {
                Debug.Log("Player touching the ground");
                RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Player cannot touch the ground");
            }
        }
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
