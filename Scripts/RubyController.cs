using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    
    public int maxHealth = 5;
    public int inicialScore = 0;
    
    
    public GameObject projectilePrefab;

    public GameObject GrassSmallPrefab;

    public int score 
    {
        get{ return currentScore; }
    }

    int currentScore;

    public int health
    {
        get { return currentHealth; }
    }
    int currentHealth;
    
    public float timeInvincible = 2f;
    bool isInvincible;
    float invicibleTimer;
     
     Rigidbody2D rigidbody2D;
     float horizontal;
     float vertical;
     float turbox;
     float turboy;
     
     
     Animator animator;
     Vector2 lookDirection = new Vector2(0,-1);
     
     AudioSource audioSource;

     bool enableshooting;
     int shoots;
     float currentSpeed;

     public float SlowTime  =2f;
     bool slowTime;
     float SlowTimer;

     private GameObject currentTeleport;
     
     public Health healths;

     
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        currentHealth = maxHealth;
        healths.SetMaxHealth(maxHealth);
        currentScore = inicialScore;
        currentSpeed = speed;
        
        
        audioSource= GetComponent<AudioSource>();

        enableshooting = false;
        //shoots = 5;
    }

    // Update is called once per frame
    void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");
         turbox = Input.GetAxis("Fire1");
         turboy = Input.GetAxis("Fire2");
         
                
        Vector2 move = new Vector2(horizontal, vertical);

        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);
        
        

        if (isInvincible)
        {
            invicibleTimer -= Time.deltaTime;
            if (invicibleTimer < 0)
                isInvincible = false;
            
        }
        if (slowTime)
        {
            SlowTimer -= Time.deltaTime;
            if (SlowTimer < 0)
                slowTime = false;
            
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
           //if(enableshooting && shoots > 0)
           // {
                Launch();
                //shoots--;
            //}
        }
        /*if(Input.GetKeyDown(KeyCode.V))
        {
            LaunchGrassSmall();
        }*/
       /* if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast( rigidbody2D.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                   character.DisplayDialog();
                }
            }
        }*/

       /*if (Input.GetKeyDown(KeyCode.T))
       {
           if (currentTeleport != null)
           {
               transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
           }
       }*/
       
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        position.x = position.x + currentSpeed * horizontal * Time.deltaTime ;
        if (turbox > 0)
        {
            position.x = position.x + currentSpeed * horizontal * 2 * Time.deltaTime;
        }
        position.y = position.y + currentSpeed * vertical * Time.deltaTime;
        if (turboy > 0)
        {
            position.y = position.y + currentSpeed * vertical * 2 * Time.deltaTime;
        }

        rigidbody2D.MovePosition(position);
        
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invicibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        healths.setHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("gameover");
        }
        
       // UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }
    public void ChangeHealthMax(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invicibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
        healths.setHealth(currentHealth);
        
        if (currentHealth <= 0)
        {
            Die();
            Debug.Log("gameover");
        }
        
       // UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }
    void Launch()
    {
        GameObject projectileObject =
            Instantiate(projectilePrefab, rigidbody2D.position + Vector2.down * 0.5f, Quaternion.identity);
        
        Projectile projectile = projectileObject.gameObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);

        animator.SetTrigger("Launch");
    }
    /*void LaunchGrassSmall()
    {
        GameObject GrassSmallObject =
            Instantiate(GrassSmallPrefab, rigidbody2D.position + Vector2.down * 0.5f, Quaternion.identity);
        
        GrassSmallProjectile GrassSmallProjectile = GrassSmallObject.GetComponent<GrassSmallProjectile>();
        GrassSmallProjectile.LaunchGrassSmall(lookDirection, 300);

        //animator.SetTrigger("Launch");
    }*/

   /* public void PlaySound(AudioClip clip)
    {
        //audioSource.PlayOneShot(clip);
    }*/
    
    public void ChangeScore(int amount)
    {
        currentScore = currentScore + amount;
        Debug.Log(currentScore);
        
        if (currentScore >= 1)
        {
            win();
            Debug.Log("winner");
        }
        
    }
    public void shooting()
    {
        enableshooting = true;
        //shoots = 5;
        Debug.Log("Shoots: ");
    }
    public void ChangeCurrentSpeed()
    {
        currentSpeed = currentSpeed*2;
        Debug.Log("speed:" + currentSpeed);
    }
    public void ChangeCurrentSpeedSlow()
    {
        if (slowTime)
                return;

            slowTime = true;
            SlowTimer = SlowTime;
            
        currentSpeed = currentSpeed/2;
        Debug.Log("speed:" + currentSpeed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            currentTeleport = other.gameObject;
            transform.position = currentTeleport.GetComponent<Teleporter>().GetDestination().position;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Teleporter"))
        {
            if (other.gameObject == currentTeleport)
            {
                currentTeleport = null;
            }
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
        //animator.SetBool("dead",true);

        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<CircleCollider2D>().enabled = false;
        //this.enabled = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        FindObjectOfType<GameManager>().GameOver();
        
    }

    void win()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        FindObjectOfType<GameManager>().win();
    }
    
}

