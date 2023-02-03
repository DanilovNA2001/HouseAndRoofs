using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

public class ParsePrice : MonoBehaviour
{
    double pr;
    String resp;
    private String Price(Transform roofs, string response)
    {
        string[] data_id = { "409835", "410156", "410063" };
        int num = 0;
        for (int i = 0; i < roofs.childCount; i++)
        {
            if (roofs.GetChild(i).gameObject.activeSelf)
            {
                num = i;
                break;
            }
        }
        String rate = Regex.Match(response, @"data-id=""" + data_id[num % 3] + @""" data-price=""([0-9]+\.[0-9]+)""").Groups[1].Value;
        return rate;
    }
    // Start is called before the first frame update
    void Start()
    {
        System.Net.WebClient wc = new System.Net.WebClient();
        resp = wc.DownloadString("https://voronezh.metallprofil.ru/shop/catalog/krovlya/profilirovannye-listy/");
        pr = double.Parse(Price(GameObject.Find("Roofs").GetComponent<Transform>(), resp), CultureInfo.InvariantCulture);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = pr.ToString();
    }
    public void PriceChange()
    {
        pr = double.Parse(Price(GameObject.Find("Roofs").GetComponent<Transform>(), resp), CultureInfo.InvariantCulture);
    }
}
