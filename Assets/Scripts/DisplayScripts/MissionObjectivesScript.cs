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
 *  selections for changing objective statuses. 
 *--------------------------------------------------------*/

public class MissionObjectivesScript : MonoBehaviour
{
    //public TextMeshProUGUI labelInstructions;
    public TextMeshProUGUI currentObjectiveLabel;
    public TMPro.TMP_Text labelInstructions;

    private GameObject confirmObject;
    private GameObject selectObject;
    public GameObject changingStatusButton;
    public Button changingCurrentObjectiveButton;

    bool retrievedBoolIsCompleted;
    private string MOname; // to display the current objective

    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    public GameObject egressObject_Renderer;
    public GameObject sitenavObject_Renderer;
    public GameObject geoscanObject_Renderer;
    public GameObject roverObject_Renderer;
    public GameObject returnnavObject_Renderer;
    
    MeshRenderer currentRenderer;
    MeshRenderer egress_Renderer;
    MeshRenderer sitenav_Renderer;
    MeshRenderer geoscan_Renderer;
    MeshRenderer rover_Renderer;
    MeshRenderer returnnav_Renderer;

    public Material red;
    public Material yellow;
    public Material green;

    void Start()
    {
        egress_Renderer = egressObject_Renderer.GetComponent<MeshRenderer>();
        sitenav_Renderer = sitenavObject_Renderer.GetComponent<MeshRenderer>();
        geoscan_Renderer = geoscanObject_Renderer.GetComponent<MeshRenderer>();
        rover_Renderer = roverObject_Renderer.GetComponent<MeshRenderer> ();
        returnnav_Renderer = returnnavObject_Renderer.GetComponent<MeshRenderer> ();

        egress_Renderer.material = red;

        labelInstructions = GameObject.Find("MissionInfo").GetComponent<TMPro.TMP_Text>();
    }
    // button to confirm change of mission objective completion status
    public void ConfirmButton()
    {
        if (confirmObject == null)
        {
            labelInstructions.text = "There is nothing selected";
        }
        else
        {
            // if the objective in question is already completed, then set it to not completed and red.
            if (FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives()[confirmObject][1] == true)
            {
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(confirmObject, false);
                currentRenderer.material = red;
            }
            // else set it to completed, not in progress, green, and clear the current objective
            else
            {


                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(confirmObject, true);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(confirmObject, false);
                currentRenderer.material = green;

                if (FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective() != confirmObject)
                {
                    // don't null it
                }
                else
                {
                    FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(null);
                }
            }
            confirmObject = null;
            currentRenderer = null;
            //changingStatusButton.interactable = false;
        }
    }

    // button logic to confirm change of current objective
    public void SelectObject()
    {
        if (selectObject == null) 
        {
            currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = "Selected: None";
        }
        else
        {
            // if there is no current objective, then check if the selected object is in progress
            if(FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective() == null)
            {
                // if the selected object is not in progress, set it to in progress, not completed, set it as 
                // the new current objective, and yellow, and clear the selected object
                if (FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives()[selectObject][0] == false)
                {
                    FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
                    FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(selectObject, false);
                    FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);
                    FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective().GetComponent<Image>().color = Color.yellow;
                    currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text =  MOname;
                    selectObject = null;
                }
                else
                {
                    currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = MOname;
                }
            }


            // if there is a current objective, set it to red, not in progress, not completed,
            // set the selected object as in progress, not completed, and set it as the current objective
            // and yellow
            else
            {
                FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective().GetComponent<Image>().color = Color.red;
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective(), false);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective(), false);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleInProgStatus(selectObject, true);
                FindObjectOfType<MissionObjectivesDataHolder>().toggleIsCompleted(selectObject, false);
                FindObjectOfType<MissionObjectivesDataHolder>().setCurrentObjective(selectObject);
                FindObjectOfType<MissionObjectivesDataHolder>().GetCurrentObjective().GetComponent<Image>().color = Color.yellow;
                currentObjectiveLabel.GetComponent<TextMeshProUGUI>().text = MOname;
                selectObject = null;
            }
            
        }
        changingCurrentObjectiveButton.interactable = false;
    }

    // if an objective is pressed, it'll become the object in question for changing its completion
    // status or in progres status. 

    public void OnButtonPressCalibration()
    {
        //changingStatusButton.interactable = true;
        //changingCurrentObjectiveButton.interactable=true;
    labelInstructions.GetComponent<TextMeshProUGUI>().text = "Selected: Calibration \n" +
            "Calibration is to make sure the VISIONKit, HoloLens 2, " +
            "and Telemetry Stream are working correctly together. ";
        confirmObject = CalibrationStatusGO;
        selectObject = CalibrationStatusGO;
        MOname = "Calibration";
    }

    public void OnButtonPressEgress()
    {
        //changingStatusButton.interactable = true;
        //changingCurrentObjectiveButton.interactable = true;
        labelInstructions.text = "Selected: Egress \n" +
            "To complete Egress, refer to the status of the UIA switches" +
            " under 'UIA'. ";
        confirmObject = EgressStatusGO;
        selectObject = EgressStatusGO;
        currentRenderer = egress_Renderer;
        MOname = "Egress";
    }

    public void OnButtonPressSiteNav()
    {
        //changingStatusButton.interactable = true;
        //changingCurrentObjectiveButton.interactable = true;
        labelInstructions.text = "Selected: Site Navigation \n" +
            "During Site Navigation, you will be placing " +
            "Flags to keep track of your path. You may " +
            "find more navigation information in the NAV Card. ";
        confirmObject = SiteNavigationStatusGO;
        selectObject = SiteNavigationStatusGO;
        currentRenderer = sitenav_Renderer;
        MOname = "Site Navigation";
    }

    public void OnButtonPressGeoScan()
    {
        //changingStatusButton.interactable = true;
        //changingCurrentObjectiveButton.interactable = true;
        labelInstructions.text = "Selected: Geological Scanning \n" +
            "During Geological Scanning, you will scan rocks with " +
            "RFID tags. You may find a list of all recently scanned " +
            "RFID tags in 'Spectrometer Data'.";
        confirmObject = GeologicalScanningStatusGO;
        selectObject = GeologicalScanningStatusGO;
        currentRenderer = geoscan_Renderer;
        MOname = "Geological Scanning";
    }

    public void OnButtonPressROVER()
    {
        //changingStatusButton.interactable = true;
        //changingCurrentObjectiveButton.interactable = true;
        labelInstructions.text = "Selected: ROVER \n" +
            "During this section, you will command the ROVER through " +
            "recall orders as well custom location orders. To find more " +
            "information, please see the ROVER Card. ";
        confirmObject = ROVERStatusGO;
        selectObject = ROVERStatusGO;
        currentRenderer = rover_Renderer;
        MOname = "ROVER";
    }

    public void OnButtonPressReturnNav()
    {
        //changingStatusButton.interactable = true;
        //changingCurrentObjectiveButton.interactable = true;
        labelInstructions.text = "Selected: Return Navigation \n" +
            "During Return Navigation, you will be retracing your " +
            "steps using the NAV Card as well as scanning any rocks " +
            "with RFID tags. ";
        confirmObject = ReturnNavigationStatusGO;
        selectObject = ReturnNavigationStatusGO;
        currentRenderer = returnnav_Renderer;
        MOname = "Return Navigation";
    }
}
