using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*-------------------------------------------------------*/
/*  Script that handles displaying the Mission Objective 
 *  buttons and labels. 
 *  
 *  Mission Objecive Buttons display colors (green, yellow, red)
 *  to indicate their respective Objective's status.
 *  
 *  Labels display information on what the current objective
 *  is as well as general information about the mission
 *  objective. 
 *      
 *  The confirm and select objects handles intermediary
 *  selections. 
 *--------------------------------------------------------*/

public class MissionObjectivesScript : MonoBehaviour
{
    public TextMeshProUGUI labelInstructions;
    public TextMeshProUGUI currentObjectiveLabel;

    private GameObject confirmObject;
    private GameObject selectObject;
    public Button changingStatusButton;
    public Button changingCurrentObjectiveButton;

    bool retrievedBoolIsCompleted;
    private string MOname; // to display the current objective

    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;


    public void ConfirmButton()
    {
        Dictionary<GameObject, bool[]> missionObjectives = FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives();
        if (confirmObject == null)
        {
            labelInstructions.GetComponent<TextMeshProUGUI>().text = "There is nothing selected";
        }
        else
        {
            retrievedBoolIsCompleted = FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives()[confirmObject][1];
            if (retrievedBoolIsCompleted == true)
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(confirmObject, false);
                //FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(confirmObject, false);
                confirmObject.GetComponent<Image>().color = Color.red;
                confirmObject = null;
            }
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(confirmObject, true);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(confirmObject, false);
                confirmObject.GetComponent<Image>().color = Color.green;
                FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(null);
                confirmObject = null;
            }
            changingStatusButton.interactable = false;
        }
    }


    public void SelectObject()
    {
        if (selectObject == null) 
        {
            currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = "Selected: None";
        }
        else
        {
            if(FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective() == null)
            {
                if (FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives()[selectObject][0] == false)
                {
                    FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
                    FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(selectObject, false);
                    FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);
                    FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective().GetComponent<Image>().color = Color.yellow;
                    selectObject = null;
                }
                else
                {
                    currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = "Current Objective: " + MOname;
                }
            }
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective().GetComponent<Image>().color = Color.red;
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective(), false);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective(), false);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(selectObject, false);
                FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);
                FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective().GetComponent<Image>().color = Color.yellow;
                selectObject = null;
            }
            


            //if (currentObjective != null)
            //{
            //    retrievedBoolIsCompleted = missionObjectives[currentObjective][1];
            //    if (retrievedBoolIsCompleted == true)
            //    {
            //        FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(currentObjective, false);
            //        currentObjective.GetComponent<Image>().color = Color.red;
            //    }
            //    else
            //    {
            //        currentObjective.GetComponent<Image>().color = Color.red;

            //    }
            //    FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(currentObjective, false);
            //    FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);


            //}
            //else
            //{
            //    FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);
            //    FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
            //}
            //currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = "Current Objective: " + MOname;
            //FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
            //selectObject.GetComponent<Image>().color = Color.yellow;
            //selectObject = null;
        }
        changingCurrentObjectiveButton.interactable = false;
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
        changingStatusButton.interactable = true;
        changingCurrentObjectiveButton.interactable=true;
    labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: Calibration \n" +
            "Calibration is to make sure the VISIONKit, HoloLens 2, " +
            "and Telemetry Stream are working correctly together. ";
        confirmObject = CalibrationStatusGO;
        selectObject = CalibrationStatusGO;
        MOname = "Calibration";
    }

    public void OnButtonPressEgress()
    {
        changingStatusButton.interactable = true;
        changingCurrentObjectiveButton.interactable = true;
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: Egress \n" +
            "To complete Egress, refer to the status of the UIA switches" +
            " under 'UIA'. ";
        confirmObject = EgressStatusGO;
        selectObject = EgressStatusGO;
        MOname = "Egress";
    }

    public void OnButtonPressSiteNav()
    {
        changingStatusButton.interactable = true;
        changingCurrentObjectiveButton.interactable = true;
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: Site Navigation \n" +
            "During Site Navigation, you will be placing " +
            "Flags to keep track of your path. You may " +
            "find more navigation information in the NAV Card. ";
        confirmObject = SiteNavigationStatusGO;
        selectObject = SiteNavigationStatusGO;
        MOname = "Site Navigation";
    }

    public void OnButtonPressGeoScan()
    {
        changingStatusButton.interactable = true;
        changingCurrentObjectiveButton.interactable = true;
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: Geological Scanning \n" +
            "During Geological Scanning, you will scan rocks with " +
            "RFID tags. You may find a list of all recently scanned " +
            "RFID tags in 'Spectrometer Data'.";
        confirmObject = GeologicalScanningStatusGO;
        selectObject = GeologicalScanningStatusGO;
        MOname = "Geological Scanning";
    }

    public void OnButtonPressROVER()
    {
        changingStatusButton.interactable = true;
        changingCurrentObjectiveButton.interactable = true;
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: ROVER \n" +
            "During this section, you will command the ROVER through " +
            "recall orders as well custom location orders. To find more " +
            "information, please see the ROVER Card. ";
        confirmObject = ROVERStatusGO;
        selectObject = ROVERStatusGO;
        MOname = "ROVER";
    }

    public void OnButtonPressReturnNav()
    {
        changingStatusButton.interactable = true;
        changingCurrentObjectiveButton.interactable = true;
        labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: Return Navigation \n" +
            "During Return Navigation, you will be retracing your " +
            "steps using the NAV Card as well as scanning any rocks " +
            "with RFID tags. ";
        confirmObject = ReturnNavigationStatusGO;
        selectObject = ReturnNavigationStatusGO;
        MOname = "Return Navigation";
    }
}
