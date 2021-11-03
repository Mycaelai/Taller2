using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;
/*
public class Player : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runSpeed = 40f;
     public bool jump = false;
     public Animator animator;
     public int maxHealth = 100;
     private int currentHealth;

     public Health healths;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healths.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("speed",Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("jumps",true);
        }

       
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        animator.SetTrigger("hurt");
        
        healths.setHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("dead",true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        
    }
    
    public void OnLanding()
    {
        animator.SetBool("jumps",false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime,false,jump);
        jump = false;
    }
}*/
    
