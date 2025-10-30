using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public float jumpforce = 8f;
    private Rigidbody RB;
    public int speed = 40;
    public int points = 0;
    public int RegularCoins = 10;
    public int lives = 4;
    private Vector3 respawnPos;
    public float deathheight = -3f;
    public Vector3 direction;
    public float tempspeed = 0;
    public float stuntimer = 4;
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
        SpaceJump();
        CheckForFallDeath();
    }
    //private void
    private void CheckForFallDeath()
    {
        if (transform.position.y < deathheight)
        {
            respawn();
        }
    }
    private void SpaceJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name);

        if (other.CompareTag("CoinR"))
        {
            points += RegularCoins;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Lazer"))
        {
            StartCoroutine(Stun());
        }
        if (other.CompareTag("Bullet"))
        {
            respawn();
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
    }
    public void respawn()
    {
        transform.position = respawnPos;
        lives--;
        if (lives <= 0)
        {
            Debug.Log("GameOver");
            SceneManager.LoadScene(2);
        }
    }
}
