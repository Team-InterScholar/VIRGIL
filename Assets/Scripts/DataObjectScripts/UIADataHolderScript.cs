using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*-------------------------------------------------------*/
/*  Script that lets an object:
 *   
 *   1. Initialize a hashmap to store UIA data provided 
 *      by the Telemetry Stream.
 *   2. Allow other objects to retrieve the hashmap.
 *   3. Allow other obejcts to modify the UIA data. 
 *   
 *   NOTE: Subject to change due to incoming Telemetry 
 *          Stream update.
 *      
 *--------------------------------------------------------*/
public class UIADataHolderScript : MonoBehaviour
{
    public Dictionary<string, bool> UIABooleans;
    public TextMeshProUGUI UIALabel;
    private bool isShowing;

    void Start()
    {
        UIABooleans = new Dictionary<string, bool>();
        UIABooleans.Add("EMU1", true);
        UIABooleans.Add("EMU2", false);
        UIABooleans.Add("O2 Supply Pressure 1", false);
        UIABooleans.Add("O2 Supply Pressure 2", false);
        UIABooleans.Add("O2 Supply Pressure Out 1", false);
        UIABooleans.Add("O2 Supply Pressure Out 2", false);
        UIABooleans.Add("EV1 Supply", false);
        UIABooleans.Add("EV2 Supply", false);
        UIABooleans.Add("EV1 Waste", false);
        UIABooleans.Add("EV2 Waste", false);
        UIABooleans.Add("EMU1 O2", false);
        UIABooleans.Add("EMU2 O2", false);
        UIABooleans.Add("O2 Vent", false);
        UIABooleans.Add("Depress Pump", false);
    }


    public Dictionary<string, bool> GetUIABooleans()
    {
        return UIABooleans;
    }

    public void setUIABoolean(string str, bool newStatus)
    {
        UIABooleans[str] = newStatus;
    }

}
