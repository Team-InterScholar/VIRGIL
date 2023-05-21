using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*-------------------------------------------------------*/
/*  
 *   
 *   1. Initialize a hashmap to store UIA data provided 
 *      by the Telemetry Stream.
 *   2. Retrieve UIA data from telemetry stream
 *   
 *   
 *   To use for ConnScript, call setUIABooleans(...)
 *   
 *      
 *--------------------------------------------------------*/






public class UIADataHolderScript : MonoBehaviour
{
    public Dictionary<string, bool> UIABooleans;
    public Dictionary<string, float> UIAFloat;

    public TMPro.TMP_Text EMU1PowerSwitchInfo;
    public TMPro.TMP_Text EV1SupplySwitchInfo;
    public TMPro.TMP_Text EV1WaterWateSwitchInfo;
    public TMPro.TMP_Text EMU1O2SupplySwitchInfo;
    public TMPro.TMP_Text O2VentSwitchInfo;
    public TMPro.TMP_Text DepressPumpSwitchInfo;
    public TMPro.TMP_Text LastUpdatedInfo;

    string LastUpdatedString;

    void Start()
    {

        //UIABooleans.Add("O2 Supply Pressure Out 2", false);
        //UIABooleans.Add("EV1 Supply", false);
        //UIABooleans.Add("EV2 Supply", false);
        //UIABooleans.Add("EV1 Waste", false);
        //UIABooleans.Add("EV2 Waste", false);
        //UIABooleans.Add("EMU1 O2", false);
        //UIABooleans.Add("EMU2 O2", false);
        //UIABooleans.Add("O2 Vent", false);
    }

    public void HouseKeeping()
    {
        UIABooleans = new Dictionary<string, bool>();
        UIABooleans.Add("EMU1_Power_Switch", false);
        UIABooleans.Add("EV1_Supply_Switch", false);
        UIABooleans.Add("EV1_Water_Waste_Switch", false);
        UIABooleans.Add("EMU1_O2_Supply_Switch", false);
        UIABooleans.Add("O2_Vent_Switch", false);
        UIABooleans.Add("Depress_Pump", false);
        UIABooleans.Add("EMU1IsBooted", false);
        UIABooleans.Add("PumpFault", false);

        UIAFloat = new Dictionary<string, float>();
        UIAFloat.Add("SupplyPressure", 0.0f);
        UIAFloat.Add("WaterLevel", 0.0f);
        UIAFloat.Add("AirlockPressure", 0.0f);


        StartCoroutine(CoroutineUpdate());
    }

    private void Update()
    {

    }

    IEnumerator CoroutineUpdate()
    {
        while (true)
        {
            displayUIABooleans();
            yield return null;
        }

    }


    public Dictionary<string, bool> GetUIABooleans()
    {
        return UIABooleans;
    }

    public void setUIABoolean(string str, bool newStatus)
    {
        UIABooleans[str] = newStatus;
    }

    public void SetUIABooleans(string telemLastUpdated,bool emu1Pwr, bool ev1Supl, bool ev1Watwste, bool emu1o2supl, bool o2vnt, bool dprspump, bool emu1booted, bool pumpfault, float supplyPressure, float waterLevel, float airlockPressure)
    {
        UIABooleans["EMU1_Power_Switch"] = emu1Pwr;
        UIABooleans["EV1_Supply_Switch"] = ev1Supl;
        UIABooleans["EV1_Water_Waste_Switch"] = ev1Watwste;
        UIABooleans["EMU1_O2_Supply_Switch"] = emu1o2supl;
        UIABooleans["O2_Vent_Switch"] = o2vnt;
        UIABooleans["Depress_Pump"] = dprspump;
        //UIABooleans["EMU1IsBooted"] = emu1booted;
        //UIABooleans["PumpFault"] = pumpfault;

        LastUpdatedString = telemLastUpdated;
    }

    public void displayUIABooleans()
    {
        EMU1PowerSwitchInfo.text = "" + UIABooleans["EMU1_Power_Switch"];
        EV1SupplySwitchInfo.text = "" + UIABooleans["EV1_Supply_Switch"];
        EV1WaterWateSwitchInfo.text = "" + UIABooleans["EV1_Water_Waste_Switch"];
        EMU1O2SupplySwitchInfo.text = "" + UIABooleans["EMU1_O2_Supply_Switch"];
        O2VentSwitchInfo.text = "" + UIABooleans["O2_Vent_Switch"];
        DepressPumpSwitchInfo.text = "" + UIABooleans["Depress_Pump"];


        LastUpdatedInfo.text = LastUpdatedString;

    //public TMPro.TMP_Text EMU1PowerSwitchInfo;
    //public TMPro.TMP_Text EV1SupplySwitchInfo;
    //public TMPro.TMP_Text EV1WaterWateSwitchInfo;
    //public TMPro.TMP_Text EMU1O2SupplySwitchInfo;
    //public TMPro.TMP_Text O2VentSwitchInfo;
    //public TMPro.TMP_Text DepressPumpSwitchInfo;

    }

}
