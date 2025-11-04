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
}
