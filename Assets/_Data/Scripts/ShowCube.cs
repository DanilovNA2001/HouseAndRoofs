using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCube : MonoBehaviour
{
    public Vector2 Center = new Vector2(0.5f, 0.5f);
    public float Size = 0.25f;
    private Material mat;

    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("_CenterX", Center.x);
        mat.SetFloat("_CenterY", Center.y);
        mat.SetFloat("_Size", Size);
    }
}
