using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostBar : MonoBehaviour
{
    public Slider slider;
    public Text text;

    public void Set_Boost(float boost)
    {
        slider.value = boost;
    }

    public void Set_MaxBoost(float maxBoost)
    {
        slider.maxValue = maxBoost;
        slider.value = maxBoost;
    }

    public float Get_Boost()
    {
        return slider.value;
    }

    public void Show_Empty()
    {
        text.enabled = true;
    }
}
