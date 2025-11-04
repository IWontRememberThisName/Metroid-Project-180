using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// Max Slavik, 10/20/25, Project plays with player movement usingthings like delta time and raycasting for jumping actions.
/// </summary>
public class PlayerControllerM : MonoBehaviour
{
    // Declaring functions.
    private Rigidbody RB;

    public float jumpforce = 8f;
    public float deathheight = -3f;
    public float tempspeed = 0;
    public float stuntimer = 4;
    public int speed = 40;
    public int RegularCoins = 10;
    public int health = 99;
    public int damageStateDuration = 5;
    public bool isDamaged = false;

    private Vector3 respawnPos;
    public Vector3 direction;

    public TMP_Text healthText;

    
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        respawnPos = transform.position;
        RB.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
        CheckForFallDeath();
        healthText.text = "HP: " + health;
    }
    //private void
    private void CheckForFallDeath()
    {
        if (transform.position.y < deathheight)
        {
            Respawn();
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
                RB.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            }
            else
            {
                Debug.Log("Player cannot touch the ground");
            }
        }
    }
    private void Movement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            //transform.position += Vector3.left * speed * Time.deltaTime;
            RB.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            direction = Vector3.right;
            RB.MovePosition(transform.position + direction * speed * Time.deltaTime);
            //transform.position += Vector3.right * speed * Time.deltaTime;
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
            SceneManager.LoadScene(2);
        }
        isDamaged = true;
        StartCoroutine(DamageState());
    }

    private IEnumerator DamageState()
    {
        yield return new WaitForSeconds(damageStateDuration);
        print("Invincibility Mode");
        isDamaged = false;
    }
}
