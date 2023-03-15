using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SpectrometerDataHolderScript : MonoBehaviour
{
    public Dictionary<int, string> spectrometerData;
    public bool isShowing;
    // Start is called before the first frame update
    void Start()
    {
        spectrometerData = new Dictionary<int, string>();
    }


    public Dictionary<int,string> GetSpectroData()
    {
        return spectrometerData;
    }
}
