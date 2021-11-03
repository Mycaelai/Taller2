using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassSmallProjectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public void LaunchGrassSmall(Vector2 direction, float force)
        {
            rigidbody2D.AddForce(direction * force);
        }


    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController ec = other.collider.GetComponent<EnemyController>();
        if (ec != null)
        {
            Destroy(other.gameObject);
        }
        Destroy(gameObject);
    }
}
