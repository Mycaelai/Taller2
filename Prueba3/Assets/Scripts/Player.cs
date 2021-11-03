using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player : MonoBehaviour
{
    public float speed = 4f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov;

    CircleCollider2D attackCollider;

    public GameObject InitialMap;
    public GameObject slashPrefab;

    bool movePrevent;
    // Start is called before the first frame update

    private void Awake()
    {
        Assert.IsNotNull(InitialMap);
        Assert.IsNotNull(slashPrefab);
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        attackCollider = transform.GetChild(0).GetComponent<CircleCollider2D>();
        attackCollider.enabled = false;

        //Camera.main.GetComponent<MainCamera>().SetBound(InitialMap);
    }

    // Update is called once per frame
    void Update()
    {
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );

        if(mov !=  Vector2.zero)
        {
            anim.SetFloat("movX", mov.x);
            anim.SetFloat("movY", mov.y);
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        AnimatorStateInfo stateInfo= anim.GetCurrentAnimatorStateInfo(0);
        bool attaking = stateInfo.IsName("Player_Attack");

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("attaking");
        }

        if (mov != Vector2.zero) attackCollider.offset = new Vector2(mov.x/4, mov.y/2);

        if (attaking)
        {
            float playbackTime = stateInfo.normalizedTime;
            print(playbackTime);
            if (playbackTime > 0.33 && playbackTime < 0.66) attackCollider.enabled = true;
            else attackCollider.enabled = false;

            
        }
        SlashAttack();
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
    void SlashAttack()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool loading = stateInfo.IsName("Player_Slash");

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            anim.SetTrigger("loading");
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            anim.SetTrigger("attaking");

            float angle = Mathf.Atan2(
                anim.GetFloat("movY"),
                anim.GetFloat("movX")
                ) * Mathf.Rad2Deg;

            GameObject slashObj = Instantiate(
                slashPrefab, transform.position,
                Quaternion.AngleAxis(angle, Vector3.forward));
            Slash slash = slashObj.GetComponent<Slash>();
            slash.mov.x = anim.GetFloat("movX");
            slash.mov.y = anim.GetFloat("movY");
        }

        if (loading)
        {
            movePrevent = true;
        }
        else
        {
            movePrevent = false;
        }
    }


    void PreventMovement()
    {
        if (movePrevent)
        {
            mov = Vector2.zero;
        }
    }
}
