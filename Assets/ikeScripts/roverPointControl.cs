using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roverPointControl : MonoBehaviour
{
    double longitude; //or strings?
    double latitude;
    public TMP_InputField userEnterLong;
    public TMP_InputField userEnterLat;
    public Button mobilizeButton;
    public TMP_Text displayEnterLong;
    public TMP_Text displayEnterLat;
    public Button recallButton;

    // Start is called before the first frame update
    private void Start()
    {
        //attach button event
        mobilizeButton.onClick.AddListener(onMobilizePress);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onMobilizePress()
    {
        longitude = double.Parse(userEnterLong.text); //use double.TryParse() if this ends up not working
        latitude = double.Parse(userEnterLat.text); //do I want them as double???

        displayEnterLong.text = userEnterLong.text;
        displayEnterLat.text = userEnterLat.text;

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
