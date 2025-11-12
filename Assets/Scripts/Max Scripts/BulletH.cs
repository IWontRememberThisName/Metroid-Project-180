using UnityEngine;
/// <summary>
/// Max Slavik 11/1/25, Designed for heavy bullets to hit an bad guy
/// </summary>
public class BulletH : MonoBehaviour
{
    public float speed;
    public bool goingleft;
    // Triggered automatically when this object collides with another collider
    private void OnCollisionEnter(Collision collision)
    {
        // If the bullet hits a breakable wall
        if (collision.gameObject.CompareTag("Breakable Wall"))
        {
            Destroy(collision.gameObject); // Destroys the wall
        }
        else if (collision.gameObject.GetComponent<EnemyM>() != null) // special enemy hit
        {
            collision.gameObject.GetComponent<EnemyM>().DamageH(); // Inflicts heavy damage
        }
        else if (collision.gameObject.GetComponent<EnemyS>() != null) //special enemy hit
        {
            collision.gameObject.GetComponent<EnemyS>().DamageH(); // Inflicts heavy damage
        }
        Destroy(gameObject);
    }
    /// <summary>
    /// Handles the Transformation either left or right as a bullet is moving
    /// </summary>
    private void Update()
    {
        if (goingleft)
        {
            transform.position += speed * Vector3.left * Time.deltaTime;
        }
        else
        {
            transform.position += speed * Vector3.right * Time.deltaTime;
        }
    }
    /// <summary>
    /// Handles collision with other things, always destroying the bullets
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //if the bullet collides with an enemy, it will take damage
        if (other.GetComponent<EnemyM>())
        {
            other.GetComponent<EnemyM>().DamageH();
            Destroy(gameObject);
        }
        else if (other.GetComponent<EnemyS>())
        {
            other.GetComponent<EnemyS>().DamageH();
            Destroy(gameObject);
        }
        else if (other.GetComponent<Floor>())
        {
            if (other.gameObject.tag == "BreakableWall")
            {
                Destroy(other.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }
}
