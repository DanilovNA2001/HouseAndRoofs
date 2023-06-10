using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintScript : MonoBehaviour
{
    Image image;
    Text text;
    void Start()
    {
        image = gameObject.GetComponent<Transform>().GetChild(0).GetComponent<Image>();
        text = gameObject.GetComponent<Transform>().GetChild(1).GetComponent<Text>();
        Color imageColor = image.color;
        Color textColor = text.color;
        imageColor.a = 0f;
        textColor.a = 0f;
    }
    void Invisible()
    {
        gameObject.SetActive(false);
    }

    public void StartInvisible()
    {
        Invoke("Invisible",10);
    }
}
