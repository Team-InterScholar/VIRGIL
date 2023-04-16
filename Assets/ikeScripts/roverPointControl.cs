using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class roverPointControl : MonoBehaviour
{
    double longitude; //or strings?
    double latitude;
    private bool isShowing;
    public GameObject roverOff;
    public GameObject roverOnIdle;
    public GameObject roverOnActive;
    public TMP_InputField userEnterLong;
    public TMP_InputField userEnterLat;
    public Button mobilizeButton;
    public Button recallButton;
    public TMP_Text displayEnterLong;
    public TMP_Text displayEnterLat;
    public TMP_Text currentLong;
    public TMP_Text currentLat;
    public TMP_Text returnPLong;
    public TMP_Text returnPLat;

    // Start is called before the first frame update
    private void Start()
    {
        isShowing = false;
        roverOff.SetActive(!isShowing);
        roverOnIdle.SetActive(isShowing);
        roverOnActive.SetActive(isShowing);
        mobilizeButton.onClick.AddListener(onMobilizePress); //attach button event
        recallButton.onClick.AddListener(onRecallPress); //attach button event
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

        roverOff.SetActive(isShowing);
        roverOnIdle.SetActive(isShowing);
        roverOnActive.SetActive(!isShowing); //turn on the green-active text object

        StartCoroutine(coroutine()); //counter for 5 seconds

        //function will then take the user's coords and randomize a point near them to set as the return point coords
    }

    public void onRecallPress()
    {
        displayEnterLong.text = returnPLong.text;
        displayEnterLat.text = returnPLat.text;

        roverOff.SetActive(isShowing);
        roverOnIdle.SetActive(isShowing);
        roverOnActive.SetActive(!isShowing); //turn on the green-active text object

        StartCoroutine(coroutine()); //counter for 5 seconds
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
