using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivesObjectScript : MonoBehaviour
{
    //public GameObject buttonGO;
    public TextMeshProUGUI labelInstructions;
    private GameObject confirmObject;
    private bool colorBool;
    private bool retrievedMOObjects;
    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    void Start()
    {
        colorBool = false;
        //buttonGO.GetComponent<Image>().color = Color.red;
    }


    // When user presses button once
    //      Display instructions
    //      Enable button to change mission objectives status
    //      User presses again
    //          BUtton changes color

    public void ConfirmButton()
    {
        if (confirmObject == null)
        {
            labelInstructions.GetComponent<TextMeshProUGUI>().text = "There is nothing selected";
        }
        else
        {
            retrievedMOObjects = FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives()[confirmObject];
            if (retrievedMOObjects == true)
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleStatus(confirmObject, false);
                confirmObject.GetComponent<Image>().color = Color.red;
                confirmObject = null;
            }
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleStatus(confirmObject, true);
                confirmObject.GetComponent<Image>().color = Color.green;
                confirmObject = null;
            }
        }
    }


    public void setColor(GameObject statusGameObject,  bool dataHolderBool)
    {
        if (dataHolderBool == true)
        {
            statusGameObject.GetComponent<Image>().color = Color.green;
        }
        else
        {
            statusGameObject.GetComponent<Image>().color = Color.red;
        }
    }

    public void OnButtonPressCalibration()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "This is where the instructions go for Calibration";
        confirmObject = CalibrationStatusGO;
    }

    public void OnButtonPressEgress()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "This is where the instructions go for Egress";
        confirmObject = EgressStatusGO;
    }

    public void OnButtonPressSiteNav()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "This is where the instructions go for SiteNav";
        confirmObject = SiteNavigationStatusGO;
    }

    public void OnButtonPressGeoScan()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "This is where the instructions go for GeoScan";
        confirmObject = GeologicalScanningStatusGO;
    }

    public void OnButtonPressROVER()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "This is where the instructions go for Rover";
        confirmObject = ROVERStatusGO;
    }

    public void OnButtonPressReturnNav()
    {
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "This is where the instructions go for return Nav";
        confirmObject = ReturnNavigationStatusGO;
    }
}
