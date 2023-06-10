using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CostCalculation : MonoBehaviour
{
    Text Square;
    Text Price;
    void Start()
    {
        Square = GameObject.Find("Square").GetComponent<Text>();
        Price = GameObject.Find("Price").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = Math.Round(Convert.ToDouble(Square.text) * Convert.ToDouble(Price.text),2).ToString();
    }
}
