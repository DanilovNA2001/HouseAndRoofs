using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastHitRoof : MonoBehaviour
{
    public GameObject UIMenu;
    GameObject staticCanvas;
    void Start()
    {
        staticCanvas = GameObject.Find("CanvasStatic");
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!UIMenu.activeSelf)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag != "Menu")
                {
                    if (hit.collider.tag == "Roof")
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse0))
                        {
                            staticCanvas.SetActive(!staticCanvas.activeSelf);
                        }
                    }
                }
            }
        }
    }
}
