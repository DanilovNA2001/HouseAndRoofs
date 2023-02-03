using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeUpX : MonoBehaviour
{
    public Slider slider;
    public float scaleMinValue;
    public float scaleMaxValue;
    float posx;
    void Start()
    {
        slider.minValue = scaleMinValue;
        slider.maxValue = scaleMaxValue;
        slider.onValueChanged.AddListener(SliderUpdate);
    }
    void SliderUpdate(float value)
    {
        transform.localScale = new Vector3(value,
            transform.localScale.y, transform.localScale.z);
    }
}
