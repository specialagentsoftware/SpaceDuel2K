using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Set_Health(float health)
    {
        slider.value = health;
    }

    public void Set_MaxHealth(float maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public float Get_Health()
    {
        return slider.value;
    }
}
