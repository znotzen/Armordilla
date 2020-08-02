using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorpionBar : MonoBehaviour
{

    public Slider slider;

    public void SetMaxOnSlider(float MaxSC)
    {
        slider.maxValue = MaxSC;
        slider.value = 0;
    }

    public void SetSlider(float ScorpionCount)
    {
        slider.value = ScorpionCount;
    }

}
