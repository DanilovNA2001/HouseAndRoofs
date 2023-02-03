using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAR : MonoBehaviour
{
    public GameObject ar;
    public GameObject menu;
    public void Click()
    {
        menu.SetActive(!menu.activeSelf);
        ar.SetActive(!ar.activeSelf);
    }
}
