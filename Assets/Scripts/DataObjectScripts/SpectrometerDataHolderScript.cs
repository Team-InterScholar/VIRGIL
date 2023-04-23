using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*-------------------------------------------------------*/
/*  Script that lets an object:
 *   
 *   1. Initalize a hashmap to store Rock samples
 *      using their RFIDs.
 *   2. Allow other objects to access the hashmap.
 *     
 *   NOTE: Subject to change due to incoming Telemetry
 *          Stream update.
 *      
 *--------------------------------------------------------*/


public class SpectrometerDataHolderScript : MonoBehaviour
{
    public Dictionary<string, float> spectrometerData;
    void Start()
    {
        spectrometerData = new Dictionary<string, float>();
        spectrometerData.Add("SiO2", 0.0f);
        spectrometerData.Add("Ti02", 0.0f);
        spectrometerData.Add("Al203", 0.0f);
        spectrometerData.Add("FeO", 0.0f);
        spectrometerData.Add("MnO", 0.0f);
        spectrometerData.Add("Mgo", 0.0f);
        spectrometerData.Add("CaO", 0.0f);
        spectrometerData.Add("K2O", 0.0f);
        spectrometerData.Add("P2O3", 0.0f);
    }


    public Dictionary<string,float> GetSpectroData()
    {
        return spectrometerData;
    }

    public void setFloat(string rock, float newfloat)
    {
        spectrometerData[rock] = newfloat;
    }
}
