using UnityEngine;

public class BulletM : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float speed;
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
}