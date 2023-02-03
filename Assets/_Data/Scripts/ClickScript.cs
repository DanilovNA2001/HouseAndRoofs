using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    public GameObject parent;
    public void OnClick()
    {
        Transform childobjs = parent.transform;
        for (int i = 0; i < childobjs.childCount; i++)
        {
            Debug.Log(childobjs.GetChild(i).gameObject.ToString());
            if (childobjs.GetChild(i).gameObject.activeSelf == true)
            {
                if (i == childobjs.childCount - 1)
                {
                    childobjs.GetChild(i).gameObject.SetActive(false);
                    i = 0;
                    childobjs.GetChild(i).gameObject.SetActive(true);
                    break;
                }
                    childobjs.GetChild(i).gameObject.SetActive(false);
                    childobjs.GetChild(i+1).gameObject.SetActive(true);
                    break;
            }
        }
    }
}
