using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Max Slavik, 11/1/25, Handles the special enemy coding, jumping patterns ect, has raycast for if the enemy sees you or not 
/// </summary>

public class EnemyS : MonoBehaviour
{
    public Transform player;
    public float sightRange = 8;
    public LayerMask obsticaleMask;
    public LayerMask playerMask; // I could just use a tag might wanna 
    public float Speed = 8f;
    public Transform LeftPoint;
    public Transform RightPoint;
    private Vector3 direction;
    private Vector3 startLeftPos;
    private Vector3 startRightPos;
    public LayerMask obstacleMask;
    public int Health = 5;
    private Rigidbody RB;
    public float jumpForce = 8f;

    private Rigidbody2D rb;
    /// <summary>
    /// Code starts with the player being trakce dthrough walls with raytags, these raytags are blocked by walls down below on the constant update function down below 
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

        if (player == null) return; // if player isnt found do nothing besides 

        Vector2 dir = player.position - transform.position;
        float dist = dir.magnitude;
        if (dist > sightRange) { rb.velocity = Vector2.zero; return; }// 
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir.normalized, dist, obstacleMask | (1 << LayerMask.NameToLayer("Player")));
        Debug.DrawRay(transform.position, dir.normalized * dist, Color.cyan); // draws the raycast to see where it would be.



        /* if (hit.collider != null && (hit.collider.CompareTag("Player") || hit.collider.gameObject.layer == LayerMask.NameToLayer("Player")))
         {
             // chase
             if (dist > stopDistance)
                 rb.velocity = dir.normalized * speed;
             else
                 rb.velocity = Vector2.zero;
         }
         else
         {
             rb.velocity = Vector2.zero; // blocked or nothing hit
         }*/
    }
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
/*{
   public Transform player;
   public float sightRange = 8;
   public LayerMask obsticaleMask;
   public LayerMask playerMask; // I could just use a tag might wanna 
   public float Speed = 8f;
   public Transform LeftPoint;
   public Transform RightPoint;
   private Vector3 direction;
   private Vector3 startLeftPos;
   private Vector3 startRightPos;
   public int Health = 5;
   private Rigidbody RB;
   public float jumpForce = 8f;

   NavMeshAgent agent; // allows the character to navigate the scene

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

   // Update is called once per frame, movement will only start when the object sees the player
   void Update()
   {
       if ()
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

   }*/
/// <summary>
/// Slightly modified version of the jump script from the player controller, though I added some of my own touches, like getting rid of the keybinding and some other small things.
/// </summary>

