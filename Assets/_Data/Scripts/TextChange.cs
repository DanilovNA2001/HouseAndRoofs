using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextChange : MonoBehaviour
{
    GameObject parent;
    Transform house;
    public Text text;
    private Material material;
    private Slider slider_z;
    private Slider slider_y;
    private Slider slider_x;
    float AreaOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float a = Vector3.Distance(p1, p2);
        float b = Vector3.Distance(p2, p3);
        float c = Vector3.Distance(p1, p3);
        
        float p = (a + b + c) * 0.5f;
        return Mathf.Sqrt(p * (p - a) * (p - b) * (p - c));
    }
    float AreaOfMesh(Mesh mesh)
    {
        float area = 0;
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        for (int i=0; i<mesh.triangles.Length; i+=3)
        {
            //Debug.Log(triangles[i]);
            Vector3 p1 = vertices[triangles[i]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            area += AreaOfTriangle(p1, p2, p3);
        }
        
        return area;
    }
    void Start()
    {
        //material = GameObject.Find("M1").GetComponent<MeshRenderer>().materials[0];
        house = GameObject.Find("House").GetComponent<Transform>().GetChild(1);
        parent = gameObject;
        slider_z = GameObject.Find("SliderZ").GetComponent<Slider>();
        slider_y = GameObject.Find("SliderY").GetComponent<Slider>();
        slider_x = GameObject.Find("SliderX").GetComponent<Slider>();
        
    }
    // Update is called once per frame
    void Update()
    {
        Transform childobjs = parent.transform;
        for (int i = 0; i < childobjs.childCount; i++)
        {
            if (childobjs.GetChild(i).gameObject.activeSelf == true)
            {
                text.text = "<b>Конфигурация: </b>" + childobjs.GetChild(i).name + '\n' 
                    + "<color=#3333ff><b>Размер дома, м. (ВШД): </b>" + Math.Round(slider_y.value * house.localScale.y / 10, 2) + " / " + Math.Round(slider_x.value * house.localScale.x / 10, 2) + " / " + Math.Round(slider_z.value * house.localScale.z / 10, 2) + "</color>";
            }    
        }
    }
}
