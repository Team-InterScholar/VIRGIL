using Microsoft.MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFinalCardsShowing : MonoBehaviour
{
    public bool isFinalCardsShowing;
    public GameObject canvas;

    public GameObject buttonsEmptyParent;

    public GameObject EVA;
    public GameObject SUIT;
    public GameObject NAV;
    public GameObject ROVER;

    public MeshRenderer EVArenderer;
    public MeshRenderer SUITrenderer;
    public MeshRenderer NAVrenderer;
    public MeshRenderer ROVERrenderer;

    bool isShowingEVA;
    bool isShowingSUIT;
    bool isShowingNAV;
    bool isShowingROVER;

    public Material transparent;
    public Material normal;
    // Start is called before the first frame update
    void Start()
    {
        EVArenderer.material = transparent;
        SUITrenderer.material = transparent;
        NAVrenderer.material = transparent;
        ROVERrenderer.material = transparent;

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


    public void isHoveredEVA()
    {
        EVArenderer.material = normal;
    }

    public void isNotHoveredEVA()
    {
        EVArenderer.material = transparent;
    }

    public void isHoveredSUIT()
    {
        SUITrenderer.material = normal;
    }

    public void isNotHoveredSUIT()
    {
        SUITrenderer.material = transparent;
    }

    public void isHoveredNAV()
    {
        NAVrenderer.material = normal;
    }

    public void isNotHoveredNAV()
    {
        NAVrenderer.material = transparent;
    }

    public void isHoveredROVER()
    {
        ROVERrenderer.material = normal;
    }

    public void isNotHoveredROVER()
    {
        ROVERrenderer.material = transparent;
    }
}
