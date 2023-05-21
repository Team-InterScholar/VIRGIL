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
    float goalLatitudeFromTelem;
    float goalLongitudeFromTelem;
    float goalLatitudeLocal;
    float goalLongitudeLocal;
    float distance;
    private bool isShowing;
    public GameObject roverOff;
    public GameObject roverOnIdle;
    public GameObject roverOnActive;
    public Button mobilizeButton;
    public Button recallButton;
    public TMP_Text goalLong;
    public TMP_Text goalLat;
    public TMP_Text currentLong;
    public TMP_Text currentLat;
    public TMP_Text returnPLong;
    public TMP_Text returnPLat;
    public MRTKTMPInputField mrtkDisplayEnterLong;   
    public MRTKTMPInputField mrtkDisplayEnterLat;
    string statusFromTelem;

    float presetAlat;
    float presetAlon;
    float presetBlat;
    float presetBlon;
    float presetClat;
    float presetClon;
    float presetDlat;
    float presetDlon;
    float presetElat;
    float presetElon;
    float presetFlat;
    float presetFlon;
    float presetGlat;
    float presetGlon;
    float presetHlat;
    float presetHlon;
    float presetIlat;
    float presetIlon;

    public TMP_Text roverPreDestinationLat;
    public TMP_Text roverPreDestinationLon;
    // Start is called before the first frame update
    private void Start()
    {

        //mobilizeButton.onClick.AddListener(onMobilizePress); //attach button event
        //recallButton.onClick.AddListener(onRecallPress); //attach button event
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HouseKeeping()
    {
        presetAlat = 29.5648150f;
        presetAlon = -95.0817410f;

        presetBlat = 29.5646824f;
        presetBlon = -95.0811564f;

        presetClat = 29.5650460f;
        presetClon = -95.0810944f;

        presetDlat = 29.5645430f;
        presetDlon = -95.0516440f;

        presetElat = 29.5648290f;
        presetElon = -95.0813750f;

        presetFlat = 29.5647012f;
        presetFlon = -95.0813750f;

        presetGlat = 29.5651359f;
        presetGlon = -95.0807408f;

        presetHlat = 29.5651465f;
        presetHlon = -95.0814092f;

        presetIlat = 29.5648850f;
        presetIlon = -95.0808360f;
        isShowing = false;
        roverOnIdle.SetActive(isShowing);
        roverOnActive.SetActive(isShowing);
        StartCoroutine(roverCoroutine());
    }

    public void OnButtonPressA()
    {
        roverPreDestinationLat.text = "" +  presetAlat;
        roverPreDestinationLon.text = "" + presetAlon;
    }

    public void OnButtonPressB()
    {
        roverPreDestinationLat.text = "" + presetBlat;
        roverPreDestinationLon.text = "" + presetBlon;
    }

    public void OnButtonPressC()
    {
        roverPreDestinationLat.text = "" + presetClat;
        roverPreDestinationLon.text = "" + presetClon;
    }

    public void OnButtonPressD()
    {
        roverPreDestinationLat.text = "" + presetDlat;
        roverPreDestinationLon.text = "" + presetDlon;
    }

    public void OnButtonPressE()
    {
        roverPreDestinationLat.text = "" + presetElat;
        roverPreDestinationLon.text = "" + presetElon;
    }

    public void OnButtonPressF()
    {
        roverPreDestinationLat.text = "" + presetFlat;
        roverPreDestinationLon.text = "" + presetFlon;
    }

    public void OnButtonPressG()
    {
        roverPreDestinationLat.text = "" + presetGlat;
        roverPreDestinationLon.text = "" + presetGlon;
    }

    public void OnButtonPressH()
    {
        roverPreDestinationLat.text = "" + presetHlat;
        roverPreDestinationLon.text = "" + presetHlon;
    }

    public void OnButtonPressI()
    {
        roverPreDestinationLat.text = "" + presetIlat;
        roverPreDestinationLon.text = "" + presetIlon;
    }

    IEnumerator roverCoroutine()
    {
        if (FindObjectOfType<ConnScript>().getIsTelemOn())
        {
            while (FindObjectOfType<ConnScript>().getIsTelemOn()){
                latitude = FindObjectOfType<ConnScript>().getRoverLat();
                currentLat.text = "" + latitude;
                longitude = FindObjectOfType<ConnScript>().getRoverLon();
                currentLong.text = "" + longitude;
                goalLatitudeFromTelem = FindObjectOfType<ConnScript>().getRoverGoalLat();
                goalLat.text = "" + goalLatitudeFromTelem;
                goalLongitudeFromTelem = FindObjectOfType<ConnScript>().getRoverGoalLon();
                goalLong.text = "" + goalLongitudeFromTelem;



                setNavigationStatus();
                yield return null;
            }
        }
        else
        {
            while (FindObjectOfType<ConnScript>().getIsTelemOn() == false){
                currentLong.text = "OFF";
                currentLat.text = "OFF";
                goalLat.text = "OFF";
                goalLong.text = "OFF";
                roverOff.SetActive(true);
                roverOnIdle.SetActive(false);
                roverOnActive.SetActive(false); 
                yield return null;
            }
        }
        StartCoroutine(roverCoroutine());
    }

    public void onMobilizePress()
    {
        string goalLatitudeStr = roverPreDestinationLat.text; //use double.TryParse() if this ends up not working
        string goalLongitudeStr = roverPreDestinationLon.text;

        foreach (char c in goalLatitudeStr)
        {
            if(c == '.' || c == '+' || c== '-')
            {
                continue;
            }
            else if (!char.IsDigit(c))
            {
                print("invalid");
                return;
            }

        }

        foreach (char c in goalLongitudeStr)
        {
            if (c == '.' || c == '+' || c == '-')
            {
                continue;
            }
            else if (!char.IsDigit(c))
            {
                print("invalid");
                return;
            }

        }

        goalLatitudeLocal = float.Parse(goalLatitudeStr);
        goalLongitudeLocal = float.Parse(goalLongitudeStr);
        /*Send to telem stream*/
        FindObjectOfType<ConnScript>().getTSSObject().SendRoverNavigateCommand(goalLatitudeLocal, goalLongitudeLocal);


    }

    public void onRecallPress()
    {
        FindObjectOfType<ConnScript>().getTSSObject().SendRoverRecallCommand();

    }
    
    public void setNavigationStatus()
    {
        statusFromTelem = FindObjectOfType<ConnScript>().getNavigationStatus();
        if (statusFromTelem != "NAVIGATING") 
        {
            roverOff.SetActive(false);
            roverOnIdle.SetActive(true);
            roverOnActive.SetActive(false); //turn on the green-active text object
        }
        else
        {
            roverOff.SetActive(false);
            roverOnIdle.SetActive(false);
            roverOnActive.SetActive(true); //turn on the green-active text object
        }
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
