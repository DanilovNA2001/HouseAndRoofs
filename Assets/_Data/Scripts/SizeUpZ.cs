using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeUpZ : MonoBehaviour
{
    public Slider slider;
    public float scaleMinValue;
    public float scaleMaxValue;
    float posz;
    void Start()
    {
        slider.minValue = scaleMinValue;
        slider.maxValue = scaleMaxValue;
        slider.onValueChanged.AddListener(SliderUpdate);
    }
    void SliderUpdate(float value)
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, value);
    }
}
