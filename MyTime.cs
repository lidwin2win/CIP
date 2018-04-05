using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Time : MonoBehaviour {

	// Use this for initialization
	void Start () {
        String t = DateTime.Now.ToString("h:mm:ss tt");
        GetComponent<TextMesh>().text = t;

	}
	
	// Update is called once per frame
	void Update () {

        String t = DateTime.Now.ToString("h:mm:ss tt");
        GetComponent<TextMesh>().text = t;

		
	}
}
