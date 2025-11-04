using UnityEngine;

public class BulletM : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float speed;
    public float damageVal = 1;
    public bool goingleft;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    // Update is called once per frame
    void Update()
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

    private void OnTriggerEnter(Collider other)
    {
        //if the bullet collides with an enemy, it will take damage
        if (other.GetComponent<EnemyM>())
        {
            other.GetComponent<EnemyM>().DamageE();
        }
    }
}