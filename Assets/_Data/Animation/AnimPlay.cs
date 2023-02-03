using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlay : MonoBehaviour
{
    private Animation anim;
    void Start()
    {
        anim = GameObject.Find("MenuButton").GetComponent<Animation>();
    }

    // Update is called once per frame
    public void Play()
    {
        anim.Play("ScrollMenu");
    }
}
