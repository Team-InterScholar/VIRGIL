using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.MixedReality.Toolkit.UX;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class roverPointControl : MonoBehaviour
{
    float longitude; //or strings?
    float latitude;
    float goalLatitude;
    float goalLongitude;
    float distance;
    private bool isShowing;
    public GameObject roverOff;
    public GameObject roverOnIdle;
    public GameObject roverOnActive;
    public Button mobilizeButton;
    public Button recallButton;
    public TMP_Text displayEnterLong;
    public TMP_Text displayEnterLat;
    public TMP_Text currentLong;
    public TMP_Text currentLat;
    public TMP_Text returnPLong;
    public TMP_Text returnPLat;
    public MRTKTMPInputField mrtkDisplayEnterLong;   
    public MRTKTMPInputField mrtkDisplayEnterLat;
    public TMP_Text navigationStatusInfo;
    // Start is called before the first frame update
    private void Start()
    {
        isShowing = false;
        roverOff.SetActive(!isShowing);
        roverOnIdle.SetActive(isShowing);
        roverOnActive.SetActive(isShowing);
        //mobilizeButton.onClick.AddListener(onMobilizePress); //attach button event
        //recallButton.onClick.AddListener(onRecallPress); //attach button event
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMobilizePress()
    {
        string goalLatitudeStr = mrtkDisplayEnterLat.text; //use double.TryParse() if this ends up not working
        string goalLongitudeStr = mrtkDisplayEnterLong.text;

        foreach (char c in goalLatitudeStr)
        {
            if (!char.IsDigit(c))
            {
                print("invalid");
                return;
            }

        }

        foreach (char c in goalLongitudeStr)
        {
            if (!char.IsDigit(c))
            {
                print("invalid");
                return;
            }

        }

        goalLatitude = float.Parse(goalLatitudeStr);
        goalLongitude = float.Parse(goalLongitudeStr);
        /*Send to telem stream*/
        displayEnterLat.text = "" + goalLatitude;
        displayEnterLong.text = "" + goalLongitude;


        //float altitude = 1.72f;
        //float x = altitude / distance;
        //float angle = Mathf.Acos(x);
        //float distanceActual = Mathf.Sin(angle) * distance;

        //// calculate position of flag
        //float radians = (FindObjectOfType<MapOutput>().getBearing() / 180.0f) * 3.14f; 
        //float horizCompVector = distanceActual * Mathf.Sin(radians);
        //float vertCompVector = distanceActual * Mathf.Cos(radians);

        ////offset rover position from user position
        //float roverXPos = FindObjectOfType<MapOutput>().getUserVector().x + horizCompVector; 
        //float roverZPos = FindObjectOfType<MapOutput>().getUserVector().z + vertCompVector; 

        //print("Rover would be going to " + roverXPos + ", " + roverZPos);

        //displayEnterLat.text = "" + roverXPos;
        //displayEnterLong.text = "" + roverZPos;

        //roverOff.SetActive(isShowing);
        //roverOnIdle.SetActive(isShowing);
        //roverOnActive.SetActive(!isShowing); //turn on the green-active text object

        //StartCoroutine(coroutine()); //counter for 5 seconds

        //function will then take the user's coords and randomize a point near them to set as the return point coords
    }

    public void onRecallPress()
    {

        displayEnterLong.text = "" + FindObjectOfType<MapOutput>().getUserVector().x;
        displayEnterLat.text = "" + FindObjectOfType<MapOutput>().getUserVector().z;


        //roverOff.SetActive(isShowing);
        //roverOnIdle.SetActive(isShowing);
        //roverOnActive.SetActive(!isShowing); //turn on the green-active text object

        //StartCoroutine(coroutine()); //counter for 5 seconds
    }


    public void setRoverLatPos(float floatFromTelem)
    {
        latitude = floatFromTelem;
        currentLat.text = "" + latitude;
    }

    public void setRoverLongPos(float floatFromTelem)
    {
        longitude = floatFromTelem;
        currentLong.text = "" + longitude;
    }
    
    public void setNavigationStatus(string statusFromTelem)
    {
        if (statusFromTelem != "NAVIGATING") 
        {
            roverOff.SetActive(true);
            roverOnIdle.SetActive(false);
            roverOnActive.SetActive(!false); //turn on the green-active text object
        }
        else
        {
            roverOff.SetActive(false);
            roverOnIdle.SetActive(true);
            roverOnActive.SetActive(!true); //turn on the green-active text object
        }
    }

    IEnumerator coroutine()
    {
        yield return new WaitForSeconds(5f);

        currentLong.text = displayEnterLong.text;
        currentLat.text = displayEnterLat.text; // within counter end is current coord change
        roverOff.SetActive(isShowing);
        roverOnActive.SetActive(isShowing);
        roverOnIdle.SetActive(!isShowing); //also within is turn on yellow-idle text object
    }

}


//Pseudocode

//public void OnMobilizePress() //mobilizePressed
//{
//    values in long and lat bars are put respectivaly collected from userEnter and put into double
//    //values in each double are then displayed onto the text object(s) roverCoords with displayEnter respectives 
//    //EXTRA) panel below card also appears with destination values for confirmation
//    //EXTRA) panel below card appears to announce mobilization
//}

//public void OnRecallPress() //recallPressed
//{
//    //EXTRA) panel below card appears asking for confirmation to recall rover
//    //EXTRA) panel below card appear to announce recall
//    //destination values changed again
//}

// Will make two seperate programs that can both change the rover status, one to turn into idle, and this one to turn online.
//   For the time being, the first mobilize press will turn status from offline to online, and then to idle after a few
//   seconds as a placeholder for the actual rover action. Will then just go back and forth with yellow and green.
// Will also make two seperate programs that can both edit the same text objects in the Location area of the ROVER card.

// Each function will also call another function updateCurrent(), which moves the proper coordinates into the right text object
