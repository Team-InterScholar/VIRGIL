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
 *      
 *--------------------------------------------------------*/


public class SpectrometerDataHolderScript : MonoBehaviour
{
    public Dictionary<int, string> spectrometerData;
    void Start()
    {
        spectrometerData = new Dictionary<int, string>();
    }


    public Dictionary<int,string> GetSpectroData()
    {
        return spectrometerData;
    }
}
