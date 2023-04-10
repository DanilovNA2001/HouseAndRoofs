using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    private Transform parent;
    private int i;
    public int activeRoofID;
    void Start()
    {
        parent = GameObject.Find("Roofs").GetComponent<Transform>();
        activeRoofID = 0;
        i = 0;
    }
    public void OnClick()
    {
        parent.GetChild(i).gameObject.SetActive(false);
        i++;
        if (i == parent.childCount)
        {
            i = 0;
        }
        parent.GetChild(i).gameObject.SetActive(true);
        activeRoofID = i;
        Debug.Log(parent.GetChild(i).gameObject.name);
    }
}
