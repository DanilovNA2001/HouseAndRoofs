using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hider : MonoBehaviour
{
    private Text text;
    public GameObject sliders;
    void Start()
    {
        text = GameObject.Find("ScaleText").GetComponent<Text>();
        text.text = "Изменить размер";
        sliders.SetActive(false);
    }
    public void Hide()
    {
        if (sliders.activeSelf == true)
        {
            text.text = "Изменить размер";
            sliders.SetActive(false);
            gameObject.GetComponent<Image>().color = new Color(0.7134212f, 0.8658904f, 0.9056604f,1f);
        }
        else
        {
            text.text = "Закрыть";
            sliders.SetActive(true);
            gameObject.GetComponent<Image>().color = Color.white;
        }
        Debug.Log(Camera.main);
    }
}
