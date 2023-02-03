using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAtCamera : MonoBehaviour
{
    Canvas canvas;
    private void Start()
    {
        canvas = gameObject.GetComponent<Canvas>();
    }
    // Update is called once per frame
    void Update()
    {
        canvas.transform.LookAt(Camera.main.transform);
        canvas.transform.Rotate(0, 180, 0);
    }
}
