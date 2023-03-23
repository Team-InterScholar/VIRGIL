using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivesDataHolder : MonoBehaviour
{
    public Dictionary<GameObject, bool[]> missionObjectives;
    private GameObject currentObjective;

    //public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    private bool[] inProgAndCompletion;

    // Start is called before the first frame update
    void Start()
    {

        // in this hashmap:
        // (Key: Mission Objective, Value: bool[] arr = new bool[] (is in progress, is completed))
        missionObjectives = new Dictionary<GameObject, bool[]>();
        currentObjective = null;
        //missionObjectives.Add(CalibrationStatusGO, false);
        missionObjectives.Add(EgressStatusGO, inProgAndCompletion = new bool[] { false, false }); 
        missionObjectives.Add(SiteNavigationStatusGO, inProgAndCompletion = new bool[] { false, false });
        missionObjectives.Add(GeologicalScanningStatusGO, inProgAndCompletion = new bool[] { false, false });
        missionObjectives.Add(ROVERStatusGO, inProgAndCompletion = new bool[] { false, false });
        missionObjectives.Add(ReturnNavigationStatusGO, inProgAndCompletion = new bool[] { false, false });
    }

    public void toggleIsCompleted(GameObject missionObject, bool newStatus)
    {
        missionObjectives[missionObject][1] = newStatus;
    }

    public void toggleInProgStatus(GameObject missionObject, bool newStatus)
    {
        missionObjectives[missionObject][0] = newStatus;
        currentObjective = missionObject;
    }

    public void setCurrentObjective(GameObject newCurrentObjective)
    {
        currentObjective = newCurrentObjective;
    }

    public Dictionary<GameObject, bool[]> GetMissionObjectives()
    {
        return missionObjectives;
    }

    public GameObject GetCurrentObjective()
    {
        return currentObjective;
    }
}


