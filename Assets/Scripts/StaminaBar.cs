using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxStamina(int stamina)
    {
        slider.maxValue = stamina;
        slider.value = stamina;
    }

    public void setStamina(int stamina)
    {
        slider.value = stamina;
    }
}
