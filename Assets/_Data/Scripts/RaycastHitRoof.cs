using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastHitRoof : MonoBehaviour
{
    public GameObject UI_Menu;
    public GameObject table;
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!UI_Menu.activeSelf)
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Roof")
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        table.SetActive(!table.activeSelf);
                    }
                }
            }
        }
    }
}
