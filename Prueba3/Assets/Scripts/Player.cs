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
    // Start is called before the first frame update

    private void Awake()
    {
        Assert.IsNotNull(InitialMap);
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
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
