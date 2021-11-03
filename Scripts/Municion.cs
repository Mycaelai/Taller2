using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Municion : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
     RubyController controller = other.collider.GetComponent<RubyController>();
        if(controller != null)
        {
            controller.shooting();
            Destroy(gameObject);
        }
    }
}
