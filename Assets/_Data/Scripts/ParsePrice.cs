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
    int roofsCount;
    String[] resp;
    String[] links;
    private double Price(Transform roofs, string response)
    {
        String rate = Regex.Match(response, @"<input class=""hidden_inp"" type=""text"" value=""+([0-9]+.[0-9]+)").Groups[1].Value;
        double doubleRate = Double.Parse(rate, CultureInfo.InvariantCulture);
        return doubleRate;
    }
    // Start is called before the first frame update
    void Start()
    {
        roofsCount = GameObject.Find("Roofs").GetComponent<Transform>().childCount;
        links = new string[roofsCount];
        resp = new String[roofsCount];
        System.Net.WebClient wc = new System.Net.WebClient();
        links[0] = "https://www.grandline.ru/tekhnonikol-shinglas-mnogosloynaya-cherepitsa-dzhaz-indigo-161759.html";
        links[1] = "https://www.grandline.ru/metallocherepitsa-modulnaya-kvinta-uno-gl-c-3d-rezom-0-5-satin-ral-7024-mokryy-asfalt-194078.html";
        links[2] = "https://www.grandline.ru/m-ch-kredo-new-0-5-satin-ral-7024-126381.html";
        links[3] = "https://www.grandline.ru/metallocherepitsa-modulnaya-kvinta-uno-gl-c-3d-rezom-0-5-satin-ral-3005-krasnoe-vino-194076.html";
        links[4] = "https://www.grandline.ru/tekhnonikol-gibkaya-cherepitsa-modern-lednik-161858.html";
        links[5] = "https://www.grandline.ru/metallocerepica-kvinta-plus-grand-line-c-3d-rezom-05-satin-ral-9006-belo-aluminievyj-429750.html";
        links[6] = "https://www.grandline.ru/metallocherepitsa-modulnaya-kvinta-uno-gl-c-3d-rezom-0-5-greensoat-pural-matt-rr-33-chernyy-ral-9005-chernyy-199695.html";
        links[7] = "https://www.grandline.ru/metallocerepica-kredo-045-drap-ral-7004-359354.html";
        for (int i=0; i<links.Length; i++)
        {
            resp[i] = wc.DownloadString(links[i]);
        }
        var roofs = GameObject.Find("Roofs").GetComponent<Transform>();
        var activeRoof = GameObject.Find("RoofChangeButton").GetComponent<ClickScript>().activeRoofID;
        pr = Price(roofs, resp[activeRoof]);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = pr.ToString();
    }
    public void PriceChange()
    {
        var roofs = GameObject.Find("Roofs").GetComponent<Transform>();
        var activeRoof = GameObject.Find("RoofChangeButton").GetComponent<ClickScript>().activeRoofID;
        pr = Price(roofs, resp[activeRoof]);
        gameObject.GetComponent<UnityEngine.UI.Text>().text = pr.ToString();
    }
    public void GetLink()
    {
        var activeRoof = GameObject.Find("RoofChangeButton").GetComponent<ClickScript>().activeRoofID;
        UnityEngine.Application.OpenURL(links[activeRoof]);
    }
}
