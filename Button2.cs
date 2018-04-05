using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;

public class Button2 : MonoBehaviour, IVirtualButtonEventHandler{

	// Use this for initialization

    private GameObject bu;

    public DateTime s;

	void Start () {


        bu = GameObject.Find("StartTime");

        bu.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);

        GameObject t = GameObject.Find("StartTime");

        Start_Stop_Clock obj = t.GetComponent<Start_Stop_Clock>();

        s = obj.start;

        Debug.Log(obj.start);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        //update = DateTime.Now;

        //var difference = update - start;

        Debug.Log("start in:  " + s);


        //TextMesh tx = GameObject.Find("Tex").GetComponent<TextMesh>();

        //tx.text = "Hwy";


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

}
