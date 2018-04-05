using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class my_Time : MonoBehaviour {

    // Use this for initialization
    void Start()
    {
        string t = DateTime.Now.ToString("h:mm:ss tt");
        GetComponent<TextMesh>().text = t;

    }

    // Update is called once per frame
    void Update()
    {

        string t = DateTime.Now.ToString("h:mm:ss tt");
        GetComponent<TextMesh>().text = t;


    }


}
