using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_enemy : MonoBehaviour
{
    public Animator animator;
    public float attackRange = 0.5f;
    public LayerMask attackMsask;
    public int attackDamage = 20;

    public Vector3 attackOffSet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void Attacks()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffSet.x;
        pos += transform.up * attackOffSet.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMsask);
        if (colInfo != null)
        {
            colInfo.GetComponent<RubyController>().takeDamage(attackDamage);
        }
    }
    
}
