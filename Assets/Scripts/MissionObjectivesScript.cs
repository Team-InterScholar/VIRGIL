using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;
using TMPro;
using UnityEngine.XR.MagicLeap;
using System.Xml;
using System;

public class MissionObjectivesScript : MonoBehaviour
{
    public TextMeshProUGUI EVALabel;
    public GameObject EVALabelGO;
    public bool isShowing;

    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    GameObject[] missionObjectsArr;



    void Start()
    {
        missionObjectsArr = new GameObject[6];
        missionObjectsArr[0] = CalibrationStatusGO;
        missionObjectsArr[1] = EgressStatusGO;
        missionObjectsArr[2] = SiteNavigationStatusGO;
        missionObjectsArr[3] = GeologicalScanningStatusGO;
        missionObjectsArr[4] = ROVERStatusGO;
        missionObjectsArr[5] = ReturnNavigationStatusGO;

        isShowing = false;

        CalibrationStatusGO.SetActive(isShowing);
        EgressStatusGO.SetActive(isShowing);
        SiteNavigationStatusGO.SetActive(isShowing);
        GeologicalScanningStatusGO.SetActive(isShowing);
        ROVERStatusGO.SetActive(isShowing);
        ReturnNavigationStatusGO.SetActive(isShowing);



    }

    public void ButtonPressed()
    {
        isShowing = !isShowing;

        EVALabelGO.SetActive(isShowing);
       
        CalibrationStatusGO.SetActive(isShowing);
        EgressStatusGO.SetActive(isShowing);
        SiteNavigationStatusGO.SetActive(isShowing);
        GeologicalScanningStatusGO.SetActive(isShowing);
        ROVERStatusGO.SetActive(isShowing);
        ReturnNavigationStatusGO.SetActive(isShowing);

        foreach (KeyValuePair<GameObject, bool> item in FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives())
        {
            if (item.Value == true) {
                item.Key.GetComponent<Image>().color = Color.green;
            } else
            {
                item.Key.GetComponent<Image>().color = Color.red;
            }
        }
    }

}
