using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;


public class getWeather : MonoBehaviour
{
    void Start() // Use this for initialization
    {

        string Zero;
        //WWW www;
        string url = "https://api.apixu.com/v1/current.json?key=9c7878a483664ef6928185252170905&q=Chennai";

        WWW www = new WWW(url);
        StartCoroutine(WaitForRequest(www));


    }

    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;

        // check for errors
        if (www.error == null)
        {

            string work = www.text;

            Debug.Log("Returned by www" + work);

            New a = JsonUtility.FromJson<New>(work);

            string tt = a.current.temp_c;

            var i = float.Parse(tt);

            Debug.Log("the type is: " + tt);

            int temperature = (int)i;

            string dis = temperature + "° C";

            Debug.Log("the temperature is: " + temperature + "° C");

            GetComponent<TextMesh>().text = dis;

            /*
            _Particle fields = JsonUtility.FromJson<_Particle>(work);
            JSON_Name = fields.location.name;
            JSON_Country = fields.location.country;
            JSON_Weather = fields.current.condition.text;
            JSON_Temperature = fields.current.temp_c;
            temperature = float.Parse(JSON_Temperature);
            Debug.Log(JSON_Name);
            Debug.Log(JSON_Country);
            Debug.Log(JSON_Weather);
            Debug.Log(JSON_Temperature);
 
             */

        }
        else
        {

            //If it comes here then no internet connectivity
            Debug.Log("There is no Internet Connection");

        }

    }

}

[System.Serializable]
public class _current
{
    public _condition condition;
    public string temp_c;

}

[System.Serializable]
public class _condition
{
    public string text;

}

[System.Serializable]
public class _location
{
    public string name;
    public string country;

}



[System.Serializable]
public class New
{

    public _condition condition;
    public _location location;
    public _current current;
    public string temp;
    public string main;

}