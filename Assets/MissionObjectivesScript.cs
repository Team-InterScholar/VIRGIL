using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;
using TMPro;

public class MissionObjectivesScript : MonoBehaviour
{
    public TextMeshProUGUI EVALabel;
    public GameObject EVALabelGO;
    private Dictionary<string, bool> missionObjectives;
    public bool isShowing;

    public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;



    void Start()
    {
        isShowing = false;

        CalibrationStatusGO.transform.SetParent(transform);

        CalibrationStatusGO.SetActive(isShowing);
        EgressStatusGO.SetActive(isShowing);
        SiteNavigationStatusGO.SetActive(isShowing);
        GeologicalScanningStatusGO.SetActive(isShowing);
        ROVERStatusGO.SetActive(isShowing);
        ReturnNavigationStatusGO.SetActive(isShowing);

        missionObjectives = new Dictionary<string, bool>();
        missionObjectives.Add("Calibration", false);
        missionObjectives.Add("Egress", false);
        missionObjectives.Add("Site Navigation", false);
        missionObjectives.Add("Geological Scanning", false);
        missionObjectives.Add("ROVER", false);
        missionObjectives.Add("Return Navigation", false);

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

    }


}
