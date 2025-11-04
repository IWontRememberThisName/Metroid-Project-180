using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;
/// <summary>
/// SlavikMax, 11/1/25 codes all types of enemies, deals with health states from bullets
/// </summary>
public class EnemyM : MonoBehaviour
{
    public float Speed = 8f;
    public Transform LeftPoint;
    public Transform RightPoint;
    private Vector3 direction;
    private Vector3 startLeftPos;
    private Vector3 startRightPos;
    public int Health = 1;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector3.left;
        startLeftPos = LeftPoint.position;
        startRightPos = RightPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
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
    public void DamageH()
    {
        Health--;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void DamageE()
    {
        Health--;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
}