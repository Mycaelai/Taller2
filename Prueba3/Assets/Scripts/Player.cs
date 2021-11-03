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

        
    }

    void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
