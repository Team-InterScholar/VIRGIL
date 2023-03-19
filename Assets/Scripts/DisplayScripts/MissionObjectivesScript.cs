using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;
using TMPro;
//using UnityEngine.XR.MagicLeap;
using System.Xml;
using System;

public class MissionObjectivesScript : MonoBehaviour
{

    public GameObject MOPanel;
    public bool isShowing;

    void Start()
    {

        isShowing = false;

        MOPanel.SetActive(isShowing);

    }

    public void ButtonPressed()
    {
        isShowing = !isShowing;

        MOPanel.SetActive(isShowing);
       

        if(isShowing == true)
        {
            foreach (KeyValuePair<GameObject, bool> item in FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives())
            {
                if (item.Value == true)
                {
                    print("detected");
                    item.Key.GetComponent<Image>().color = Color.green;
                }
                else
                {
                    item.Key.GetComponent<Image>().color = Color.red;
                }
            }
        }

    }

    public bool isMOShowing()
    {
        return isShowing;
    }

    public void setIsShowingMO(bool display)
    {
        isShowing = display;
    }

}
