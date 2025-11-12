using UnityEngine;

public class EnemyS : MonoBehaviour
{
    public Transform player;
    public float Range = 8f;
    public float Speed = 8f;
    public float jumpForce = 8f;
    public int Health = 5;

    public LayerMask obstacleMask;
    public LayerMask playerMask;

    private Rigidbody RB;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
        //Find our player and where they are, basicly setting up the update function.
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;

        // Set layer masks (if not assigned in Inspector)
        obstacleMask = LayerMask.GetMask("Obstacle");
        playerMask = LayerMask.GetMask("Player");
    }
    /// <summary>
    /// Handles the detection and how it works with the player using layer masks and hasHit Raycasts to handle the issue
    /// </summary>
    void Update()
    {
            if (player == null) return;

            Vector3 dir = player.position - transform.position;
            float Distance = dir.magnitude;
            // 
            if (Distance > Range)
            {
                RB.velocity = Vector3.zero;
                return;
            }
            //combine the layers so it only chcks for a player or obsticals at the same time
            int CombinedLayers = obstacleMask | playerMask;
        RaycastHit hit;
        //Raycast for the trace back onto the player
        bool hasHit = Physics.Raycast(transform.position, dir.normalized, out hit, Distance, CombinedLayers);

            Debug.DrawRay(transform.position, dir.normalized * Distance, Color.cyan);
            //when the player is visible and no raycast has hit a layer that has the Obstical tag
            if (hasHit && hit.collider.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            
            RB.velocity = dir.normalized * Speed;
        }
        else
        {
            // Wall in the way or no line of sight
            RB.velocity = Vector3.zero;
        }
    }
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
