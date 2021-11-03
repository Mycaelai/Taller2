using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fil;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        
       fil.color = gradient.Evaluate(1f);
    }

    public void setHealth(int health)
    {
        slider.value = health;
        fil.color = gradient.Evaluate(slider.normalizedValue);
    }
}
