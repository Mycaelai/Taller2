using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class restaure : MonoBehaviour
{
   void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null)
        {
            if (controller.health < controller.maxHealth)
            {
               controller.ChangeHealthMax(5);
               Destroy(gameObject); 
               
               //controller.PlaySound(collectedClip);
            }
        }
    }
}
