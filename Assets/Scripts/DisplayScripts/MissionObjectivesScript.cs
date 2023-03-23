using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivesScript : MonoBehaviour
{
    //public GameObject buttonGO;
    public TextMeshProUGUI labelInstructions;
    public TextMeshProUGUI currentObjectiveLabel;

    private GameObject confirmObject;
    private GameObject selectObject;
    bool retrievedBoolIsCompleted;
    bool retrievedBoolIsInProg;
    private string MOname;

    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    public Button changingStatusButton;
    public Button changingCurrentObjectiveButton;

    void Start()
    {
        //buttonGO.GetComponent<Image>().color = Color.red;
    }


    // When user presses button once
    //      Display instructions
    //      Enable button to change mission objectives status
    //      User presses again
    //          BUtton changes color

    public void ConfirmButton()
    {
        Dictionary<GameObject, bool[]> missionObjectives = FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives();
        if (confirmObject == null)
        {
            labelInstructions.GetComponent<TextMeshProUGUI>().text = "There is nothing selected";
        }
        else
        {
            retrievedBoolIsCompleted = missionObjectives[confirmObject][1];
            if (retrievedBoolIsCompleted == true)
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(confirmObject, false);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(confirmObject, false);
                confirmObject.GetComponent<Image>().color = Color.red;
                confirmObject = null;
            }
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(confirmObject, true);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(confirmObject, false);
                confirmObject.GetComponent<Image>().color = Color.green;
                confirmObject = null;
            }
            changingStatusButton.interactable = false;
        }
    }


    public void SelectObject()
    {
        GameObject currentObjective = FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective();
        Dictionary<GameObject, bool[]> missionObjectives = FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives();
        if (selectObject == null) 
        {
            currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = "Selected: None";
        }
        else
        {
            if (currentObjective != null)
            {
                retrievedBoolIsCompleted = missionObjectives[currentObjective][1];
                if (retrievedBoolIsCompleted == true)
                {
                    currentObjective.GetComponent<Image>().color = Color.red;
                }
                else
                {
                    currentObjective.GetComponent<Image>().color = Color.red;

                }
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(currentObjective, false);
                FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);


            }
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
            }
            currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = "Current Objective: " + MOname;
            FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
            selectObject.GetComponent<Image>().color = Color.yellow;
            selectObject = null;
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
