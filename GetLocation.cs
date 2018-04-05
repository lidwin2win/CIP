using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;


public class GetLocation : MonoBehaviour {

    // Use this for initialization

    string s;

	void Start () {

        StartCoroutine(Lat_Long());

	}


    IEnumerator Lat_Long() {

        var Latitude = 13.0472480;
        var Longitude = 80.22778;

        string Zero;

        Debug.Log("Try getting Location!");

        //yield return new WaitForSeconds(5);

        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("I am going to yield break");
            //StartCoroutine(Location(www));



            yield break;
        }

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            Debug.Log("TImed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            Debug.Log("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

            Debug.Log("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

            s = "Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude;// +" " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp;

            GetComponent<TextMesh>().text = s;



            Latitude = Input.location.lastData.latitude;

            Longitude = Input.location.lastData.longitude;



            var api_map = "https://60c79d3c.ngrok.io/benny?latitude=" + Latitude+ "&longitude=" +Longitude;

            WWW www = new WWW(api_map);
            StartCoroutine(Location(www));



        }
        Input.location.Stop();

        // var api_map = "http://maps.googleapis.com/maps/api/geocode/json?latlng=" + Latitude + "," + Longitude + "&sensor=true";

        // WWW www = new WWW(api_map);
        // StartCoroutine(Location(www));



    }

    IEnumerator Location(WWW www)
    {

        yield return www;

       
            if (www.error == null)
            {

                string work = www.text;

            string x = s;

                Debug.Log("The location api returns"+work);

            x = work;

            GetComponent<TextMesh>().text = x;

            //New1 a = JsonUtility.FromJson<New1>(work);

            //dynamic a = JObject.Parse(work);

            //string tt = a.formatted_address;
            //Debug.Log("The formated is: "+tt);
            //GetComponent<TextMesh>().text = tt;

            //var i = float.Parse(tt);


        }

            else {

                GetComponent<TextMesh>().text = "No internet";

            Debug.Log("No Internet");

            }

        }

        // Stop service if there is no need to query location updates continuously


        //StartCoroutine(get_City(Latitude, Longitude));

    }


[System.Serializable]
public class New1
{

    public string formatted_address;

}


