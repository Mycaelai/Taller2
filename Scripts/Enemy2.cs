using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float VisionRadius;
    public float attackRadius;
    public float speed;

    private GameObject player;

    private Vector3 initialPosition;
    
    //Animatior anim;
    private Rigidbody2D rb2d;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;

        //anim = GetComponent<Animatior>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = initialPosition;

        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            player.transform.position - transform.position,
            VisionRadius,
            1 << LayerMask.NameToLayer("Default"));

        Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
        
        Debug.DrawRay(transform.position, forward, Color.red);

        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                target = player.transform.position;
            }
        }

        float distance = Vector3.Distance(target, transform.position);
        Vector3 dir = (target - transform.position).normalized;

       if (target != initialPosition && distance < attackRadius)
        {
            //anim.SetFloat("movx", dir.x);
            //anim.SetFloat("movy", dir.y);
            //anim.Play("Enemy_Walk", -1, 0);
        }
        else
        {
            rb2d.MovePosition(transform.position + dir * speed * Time.deltaTime);

            //anim.speed = 1;
           // anim.SetFloat("movx", dir.x);
           // anim.SetFloat("movy", dir.y);
           // anim.SetBool("walkin", true);
        }

        if (target == initialPosition && distance < 0.02f)
        {
            transform.position = initialPosition;

            //anim.SetBool("walking", false);
        }
        
        Debug.DrawLine(transform.position, target, Color.green);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, VisionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }
}
