using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

 	Color colorStart = new Color(0.9f,0.9f,0.9f,1);
    Color colorEnd = new Color(1f,0,1f,1);
    float duration = 20.0f;
    Renderer rend;

	// Use this for initialization

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.color = Color.Lerp(colorStart, colorEnd, lerp);
    }
}