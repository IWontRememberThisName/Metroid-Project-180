using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Max Slavik, 11/1/25, Handles the special enemy coding, jumping patterns ect
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
    /// <summary>
    /// Calls all of the directions including the rigid body so the enemy can jump 
    /// </summary>
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        direction = Vector3.left;
        startLeftPos = LeftPoint.position;
        startRightPos = RightPoint.position;
        InvokeRepeating(nameof(Jump), 2.0f, 3.0f);


    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    /// <summary>
    /// Handles the direction and positioning of the enemy so it doesnt go over bounds, works the same with the regular enemy script.
    /// </summary>
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
    /// <summary>
    /// Slightly modified version of the jump script from the player controller, though I added some of my own touches, like getting rid of the keybinding and some other small things.
    /// </summary>
    private void Jump()
    {
        RaycastHit hit; //calls the raycast

        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.5f)) // Debugs everything when it comes to the enemy movement 
        {
            Debug.Log("Enemy jumps!");
            RB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            Debug.Log("JumpCalled");
        }
    }
    /// <summary>
    /// Handles the damage from the bullet caused by the player. 
    /// </summary>
    public void DamageH() // Damage for the special enemy called with each bullet 
    {
        Health -= 3;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DamageE() // damage for the special enemy called with each bullet
    {
        Health--;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
