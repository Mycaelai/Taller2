using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    float DestroyTime  =1.0f;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void Launch(Vector2 direction, float force)
        {
            rigidbody2D.AddForce(direction * force);
        }
    // Update is called once per frame
    /*void Update()
    {
        DestroyTime -= Time.deltaTime;

        if(transform.position.magnitude > 1000.0f || DestroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }*/
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController e = other.collider.GetComponent<EnemyController>();
        if (e != null)
        {
            e.Fix();
        }
        Destroy(gameObject);
    }
    
}
