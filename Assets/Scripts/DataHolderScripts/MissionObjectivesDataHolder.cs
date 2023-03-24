using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MissionObjectivesDataHolder : MonoBehaviour
{
    /*-------------------------------------------------------*/
    /*  Script that lets an object:
     *   
     *   1. Initialize a hashmap to store Mission Objectives 
     *      and their statuses.
     *   2. Allow other objects to retrieve this hashmap.
     *   3. Allow other objects to modify the statuses of the
     *      Mission Objectives.
     *   4. Allow other objects to modify the Current
     *      Mission Objective.
     *      
     *--------------------------------------------------------*/

    public Dictionary<GameObject, bool[]> missionObjectives;

     //Each gameobject references the Mission Objective buttons
     //so that their appearances can be manipulated during 
     //runtime.

     //Each bool array holds two indices for if a Mission
     //Objective is in progress and if it is completed.


    //public GameObject CalibrationStatusGO; disabled until the main features are built
    public GameObject EgressStatusGO;
    public GameObject SiteNavigationStatusGO;
    public GameObject GeologicalScanningStatusGO;
    public GameObject ROVERStatusGO;
    public GameObject ReturnNavigationStatusGO;

    private bool[] inProgAndCompletion;
    private GameObject currentObjective;

    void Start()
    {
        missionObjectives = new Dictionary<GameObject, bool[]>();
        currentObjective = null;
        //missionObjectives.Add(CalibrationStatusGO, false);
        missionObjectives.Add(EgressStatusGO, inProgAndCompletion = new bool[] { false, false }); 
        missionObjectives.Add(SiteNavigationStatusGO, inProgAndCompletion = new bool[] { false, false });
        missionObjectives.Add(GeologicalScanningStatusGO, inProgAndCompletion = new bool[] { false, false });
        missionObjectives.Add(ROVERStatusGO, inProgAndCompletion = new bool[] { false, false });
        missionObjectives.Add(ReturnNavigationStatusGO, inProgAndCompletion = new bool[] { false, false });
    }

    public Dictionary<GameObject, bool[]> GetMissionObjectives()
    {
        return missionObjectives;
    }


    // functions to modify the booleans in each array;
    // the first index in the array refers to "in progress"
    // and the second index is for if the objective is complete

    public void toggleIsCompleted(GameObject missionObject, bool newStatus)
    {
        missionObjectives[missionObject][1] = newStatus;
    }

    public void toggleInProgStatus(GameObject missionObject, bool newStatus)
    {
        missionObjectives[missionObject][0] = newStatus;
        currentObjective = missionObject;
    }


    // functions to modify the current objective
    public void setCurrentObjective(GameObject newCurrentObjective)
    {
        currentObjective = newCurrentObjective;
    }


    public GameObject GetCurrentObjective()
    {
        return currentObjective;
    }
}


