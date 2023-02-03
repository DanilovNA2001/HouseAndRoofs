using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseVisible : MonoBehaviour
{
    private Text text;
    public GameObject house;
    void Start()
    {
        text = GameObject.Find("OnOffText").GetComponent<Text>();
    }

    public void Visibility()
    {
        if (house.activeSelf == false)
        {
            text.text = "Вкл.";
            text.color = new Color(0.07809719f, 0.6132076f, 0.07883155f, 1f);
        }
        else
        {
            text.text = "Выкл.";
            text.color = Color.red;
        }
        house.SetActive(!house.activeSelf);
    }
}
