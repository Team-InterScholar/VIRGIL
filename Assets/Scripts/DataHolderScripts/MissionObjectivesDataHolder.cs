using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivesDataHolder : MonoBehaviour
{
    public Dictionary<GameObject, bool> missionObjectives;

    //public GameObject CalibrationStatusGO;
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;



    // Start is called before the first frame update
    void Start()
    {
        missionObjectives = new Dictionary<GameObject, bool>();
        //missionObjectives.Add(CalibrationStatusGO, false);
        missionObjectives.Add(EgressStatusGO, false);
        missionObjectives.Add(SiteNavigationStatusGO, false);
        missionObjectives.Add(GeologicalScanningStatusGO, false);
        missionObjectives.Add(ROVERStatusGO, false);
        missionObjectives.Add(ReturnNavigationStatusGO, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleStatus(GameObject missionObject, bool newStatus)
    {
        missionObjectives[missionObject] = newStatus;


        //foreach (KeyValuePair<GameObject, bool> item in missionObjectives)
        //{
        //    print(item.Key + " " + item.Value);
        //}
    }

    public Dictionary<GameObject, bool> GetMissionObjectives()
    {
        return missionObjectives;
    }
}


