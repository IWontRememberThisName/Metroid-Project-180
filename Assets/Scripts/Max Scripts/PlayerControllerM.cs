using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Max Slavik, Shawn Evans, 10/20/25, Project plays with player movement using things like delta time and raycasting for jumping actions. Item pick up functions are also included here.
/// </summary>
public class PlayerControllerM : MonoBehaviour
{
    // Declaring functions.
    private Rigidbody RB;

    public float jumpForce = 8f;
    public float deathheight = -3f;
    public float tempspeed = 0;
    public float stuntimer = 4;
    public float flashDuration = 0.1f;
    public int speed = 40;
    public int RegularCoins = 10;
    public int health = 99;
    public int damageStateDuration = 5;
    public bool isDamaged = false;
    public int healthPickUp = 15;

    public HealthPack HealthPackRefrence; //healthpack refrence to be assighned
    private Vector3 respawnPos;
    public Vector3 direction;

    public TMP_Text healthText;

    public Quaternion facingLeft = Quaternion.Euler(0f, 180f, 0f);
    public Quaternion facingRight = Quaternion.Euler(0f, 0f, 0f);

    public Renderer rend;

    public Color flashColor = Color.red;
    public Color originalColor;

    


    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        respawnPos = transform.position;
        RB.freezeRotation = true;
        originalColor = rend.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        CheckForFallDeath();
        healthText.text = "HP: " + health;
        //CheckEnemyCount();
    }
    
    private void CheckForFallDeath()
    {
        if (transform.position.y < deathheight)
        {
            SceneManager.LoadScene(1);
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
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            direction = Vector3.left;
            //transform.position += Vector3.left * speed * Time.deltaTime;
            RB.MovePosition(transform.position + direction * speed * Time.deltaTime);

            //sets rotation to a fixed value
            transform.rotation = facingLeft;
        }

        if (Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            RB.MovePosition(transform.position + direction * speed * Time.deltaTime);
            //transform.position += Vector3.right * speed * Time.deltaTime;

            transform.rotation = facingRight;
        }
    }
    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);
        if (other.CompareTag("Lazer"))
        {
            StartCoroutine(Stun());
        }
        if (other.CompareTag("Bullet"))
        {
            Respawn();
        }
        IEnumerator Stun()
        {
            Debug.Log("Player has been stunned!");
            int currentplayerspeed = speed;
            speed = 0;

            // Stop all motion immediately
            RB.velocity = Vector3.zero;
            RB.angularVelocity = Vector3.zero;

            yield return new WaitForSeconds(stuntimer);

            speed = currentplayerspeed;
            Debug.Log("Stun ended. Speed restored to " + speed);
        }
    }*/
    /// <summary>
    /// Changes scene if health is depleted and makes the player invulnerable for a short period 
    /// </summary>
    public void Respawn()
    {
        if (health <= 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(1);
        }
        isDamaged = true;
        StartCoroutine(Flash());
        StartCoroutine(DamageState());
    }

    /// <summary>
    /// Increases the jump force by 10
    /// </summary>
    public void AddJump()
    {
        jumpForce += 10;
    }
    /// <summary>
    /// A coroutine that waits for damageStateDuration before setting isDamaged to false
    /// </summary>
    /// <returns></returns>
    private IEnumerator DamageState()
    {
        //print("Invincibility Mode");
        yield return new WaitForSeconds(damageStateDuration);
        isDamaged = false;
    }

    /// <summary>
    /// A coroutine that swaps the player mesh color from flashColor to its original, alternating every flashDuration seconds.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Flash()
    {
        while (isDamaged)
        {
            //player mesh turns red 
            rend.material.color = flashColor;
            yield return new WaitForSeconds(flashDuration);
            //player mesh turns back to its original color after flashDuration seconds
            rend.material.color = originalColor;
            yield return new WaitForSeconds(flashDuration);
        }
    }
    /// <summary>
    /// A funnction that gets called from the Health Pack, Adds health to the player if they get damaged.
    /// </summary>
    public void HealthPack()
    {
        Debug.Log("Health pack picked up");
        health += HealthPackRefrence.HealthPackNum;
        Debug.Log("Health Pack registered");
    }
    /// <summary>
    /// A funciton that gets called from the extra health pack, sets the players health back up to full. 
    /// </summary>
    public void ExtraHealth()
    {
        health = 100;
    }

    
}
