using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoofArea : MonoBehaviour
{
    Transform house;
    Transform roofs;
    public GameObject normalRoof;
    Mesh roofMesh;
    public Slider slider_z;
    public Slider slider_y;
    public Slider slider_x;
    float AreaOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        p1 = new Vector3(p1.x * house.localScale.x * slider_x.value, p1.y * house.localScale.y * slider_y.value, p1.z * house.localScale.z * slider_z.value);
        p2 = new Vector3(p2.x * house.localScale.x * slider_x.value, p2.y * house.localScale.y * slider_y.value, p2.z * house.localScale.z * slider_z.value);
        p3 = new Vector3(p3.x * house.localScale.x * slider_x.value, p3.y * house.localScale.y * slider_y.value, p3.z * house.localScale.z * slider_z.value);
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
        for (int i = 0; i < mesh.triangles.Length; i += 3)
        {
            Vector3 p1 = vertices[triangles[i]];
            Vector3 p2 = vertices[triangles[i + 1]];
            Vector3 p3 = vertices[triangles[i + 2]];
            area += AreaOfTriangle(p1, p2, p3);
        }

        return area;
    }
    float AreaOfRoof(Transform roof)
    {
        float area = 0;
        if (roof.tag == "Normal")
        {
            area = AreaOfMesh(normalRoof.GetComponent<MeshFilter>().mesh) / 5f;
        }
        else if (roof.tag == "Gable")
        {
            float height = house.localScale.y / 9f;
            float width = house.localScale.z * 1.1f;
            float length = house.localScale.x * 1.3f;
            area = 2 * width * Mathf.Sqrt(Mathf.Pow(height, 2f) + Mathf.Pow(length / 2, 2f));
        }
        else if (roof.tag == "Hip")
        {
            float widthFirst = house.localScale.z * 1.1f;
            float widthSecond = house.localScale.x * 1.1f;
            float widthThree = widthFirst / 3f;
            float heightFirst = Mathf.Sqrt(Mathf.Pow(widthSecond / 2f, 2f) + Mathf.Pow(house.localScale.y / 4f, 2f));
            float heightSecond = Mathf.Sqrt(Mathf.Pow(widthFirst/3f,2f)+Mathf.Pow(house.localScale.y/4f,2f));
            //float lengthB = Mathf.Sqrt(Mathf.Pow(widthSecond / 2f, 2f) + Mathf.Pow(heightSecond, 2f));
            area = 2 * (widthSecond * heightSecond / 2f + (widthFirst + widthThree) * heightFirst / 2f);
        }    
        return area;
    }
    void Start()
    {
        var activeRoof = GameObject.Find("RoofChangeButton").GetComponent<ClickScript>().activeRoofID;
        house = GameObject.Find("House").GetComponent<Transform>().GetChild(1);
        roofs = GameObject.Find("House").GetComponent<Transform>().GetChild(0);
        //roofMesh = roof.gameObject.GetComponent<MeshFilter>().mesh;
        Debug.Log(slider_x.value);
        Debug.Log(slider_y.value);
        Debug.Log(slider_z.value);
        gameObject.GetComponent<Text>().text = AreaOfRoof(roofs.GetChild(activeRoof)).ToString();
        /*НУЖНО РАССЧИТАТЬ ПЛОЩАДЬ ПОВЕРХНОСТИ КРОВЛИ ОТДЕЛЬНО ДЛЯ ДВУСКАТНЫХ (ЧЕРЕЗ СООТНОШЕНИЯ)
         И ОТДЕЛЬНО НЕДВУСКАТНЫХ(ЧЕРЕЗ ПЕРВУЮ КРОВЛЮ)*/
    }
    void Update()
    {
        var activeRoof = GameObject.Find("RoofChangeButton").GetComponent<ClickScript>().activeRoofID;
        house = GameObject.Find("House").GetComponent<Transform>().GetChild(1);
        roofs = GameObject.Find("House").GetComponent<Transform>().GetChild(0);
        gameObject.GetComponent<Text>().text = Math.Round(AreaOfRoof(roofs.GetChild(activeRoof)),2).ToString();
    }
}
