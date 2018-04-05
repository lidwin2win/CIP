using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;
using System.Threading;
using System.Timers;

using UnityEngine.Timeline;

public class Start_Stop_Clock : MonoBehaviour, IVirtualButtonEventHandler {
    
    public DateTime start;
    DateTime update;

    private GameObject bu;

    // Use this for initialization
    void Start() {

        /*text = GetComponent<TextMesh>();*/

        bu = GameObject.Find("StartTime");

        bu.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
       
       string t = DateTime.Now.ToString("h:mm:ss tt");

       start = DateTime.Now;
        //GetComponent<TextMesh>().text = t;

       TextMesh tx = GameObject.Find("Tex").GetComponent<TextMesh>();

       tx.text = t;

       Debug.Log("You started me!");
 }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb) {

        update = DateTime.Now;

        var difference = update - start;

        Debug.Log("the difference is: "+difference);


        TextMesh tx = GameObject.Find("Tex").GetComponent<TextMesh>();

        tx.text = difference.ToString();


    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }

}
