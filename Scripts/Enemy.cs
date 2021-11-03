using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    private int e_currentHealth;
    public Transform player;
    public bool isFlipped = false;
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        e_currentHealth = maxHealth;
        Player = GameObject.FindGameObjectWithTag("Player");
        player = Player.transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        
    }
    public void TakeDamage(int damage)
    {
        e_currentHealth -= damage;
        
        animator.SetTrigger("hurt");

        if (e_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetBool("Dead",true);

        GetComponent<Collider2D>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        
    }
   /* void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            //if (controller.score > controller.inicialScore)
            //{
            contr
            Destroy(gameObject); 
               
            //controller.PlaySound(collectedClip);
            //}
        }
    }*/
}
