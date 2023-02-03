using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeUpY : MonoBehaviour
{
    public Slider slider;
    private Canvas canvas_static;
    public float scaleMinValue;
    public float scaleMaxValue;
    private float old_posy;
    void Start()
    {
        canvas_static = GameObject.Find("CanvasStatic").GetComponent<Canvas>();
        old_posy = canvas_static.transform.localPosition.y;
        slider.minValue = scaleMinValue;
        slider.maxValue = scaleMaxValue;
        slider.onValueChanged.AddListener(SliderUpdate);
    }
    //void Update()
    //{
    //    Debug.Log(transform.GetChild(0));
    //    Debug.Log(transform.GetChild(0).localScale);
    //}
    void SliderUpdate(float value)
    {
        transform.localScale = new Vector3(transform.localScale.x, value, transform.localScale.z);
        canvas_static.transform.localPosition = new Vector3(canvas_static.transform.localPosition.x, old_posy + value/5, canvas_static.transform.localPosition.z);
    }
}
