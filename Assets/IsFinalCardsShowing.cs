using Microsoft.MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFinalCardsShowing : MonoBehaviour
{
    public bool isFinalCardsShowing;
    public GameObject canvas;

    public GameObject EVA;
    public GameObject SUIT;
    public GameObject NAV;
    public GameObject ROVER;

    bool isShowingEVA;
    bool isShowingSUIT;
    bool isShowingNAV;
    bool isShowingROVER;
    // Start is called before the first frame update
    void Start()
    {
        isFinalCardsShowing = false;
        isShowingEVA = EVA.GetComponent<ButtonBehaviour>().getIsShowing();
        isShowingSUIT = SUIT.GetComponent<ButtonBehaviour>().getIsShowing();
        isShowingNAV = NAV.GetComponent<ButtonBehaviour>().getIsShowing(); 
        isShowingROVER = ROVER.GetComponent<ButtonBehaviour>().getIsShowing();
    }

    public void setMaxView()
    {
        isShowingEVA = EVA.GetComponent<ButtonBehaviour>().getIsShowing();
        isShowingSUIT = SUIT.GetComponent<ButtonBehaviour>().getIsShowing();
        isShowingNAV = NAV.GetComponent<ButtonBehaviour>().getIsShowing();
        isShowingROVER = ROVER.GetComponent<ButtonBehaviour>().getIsShowing();

        if (isShowingEVA || isShowingSUIT || isShowingNAV || isShowingROVER)
        {
            canvas.GetComponent<Follow>().MaxViewHorizontalDegrees = 60f;
            canvas.GetComponent<Follow>().MaxViewVerticalDegrees = 60f;
            canvas.GetComponent<Follow>().MoveLerpTime = 0.1f;
            canvas.GetComponent<Follow>().RotateLerpTime = 0.1f;
        }
        else
        {
            canvas.GetComponent<Follow>().MaxViewHorizontalDegrees = 0f;
            canvas.GetComponent<Follow>().MaxViewVerticalDegrees = 0f;
            canvas.GetComponent<Follow>().MoveLerpTime = 0f;
            canvas.GetComponent<Follow>().RotateLerpTime = 0f;
        }
    }
}
