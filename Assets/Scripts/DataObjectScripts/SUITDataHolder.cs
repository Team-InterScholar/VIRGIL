using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SUITDataHolder : MonoBehaviour
{
    public Dictionary<string, float> SUITFloatData;
    public Dictionary<string, string> SUITTimeLeftData;


    public TMPro.TMP_Text PrimaryOxygenInfo;
    public TMPro.TMP_Text PrimaryOxygenPressure;
    public TMPro.TMP_Text PrimaryOxygenRate;
    public TMPro.TMP_Text SecondaryOxygenInfo;
    public TMPro.TMP_Text SecondaryOxygenPressure;
    public TMPro.TMP_Text SecondaryOxygenrate;
    public TMPro.TMP_Text OxygenTimeLeftInfo;

    public TMPro.TMP_Text H2OTimeLeftInfo;
    public TMPro.TMP_Text LiquidPressureInfo;
    public TMPro.TMP_Text GasPressureInfo;
    public TMPro.TMP_Text H2OCapacity;

    public TMPro.TMP_Text HeartRateInfo;
    
    public TMPro.TMP_Text BatteryTimeLeftInfo;
    public TMPro.TMP_Text BatteryPercentageTimeLeftInfo;
    public TMPro.TMP_Text OutputInfo;
    public TMPro.TMP_Text BatteryCapacityInfo;
    public TMPro.TMP_Text H2OOxygenTimeLeftInfo;

    public TMPro.TMP_Text FanTachometerInfo;
    public TMPro.TMP_Text TemperatureInfo;
    public TMPro.TMP_Text SuitPressureInfo;
    public TMPro.TMP_Text SubPressureInfo;

    public TMPro.TMP_Text HeartRateLabel;
    public TMPro.TMP_Text SuitPressureLabel;
    public TMPro.TMP_Text FanLabel;
    public TMPro.TMP_Text O2PressureLabel;
    public TMPro.TMP_Text O2RateLabel;
    public TMPro.TMP_Text Batt_CapacityLabel;


    void Start()
    {
        SUITFloatData = new Dictionary<string, float>();
        SUITTimeLeftData = new Dictionary<string, string>();
        SUITFloatData.Add("P_O2Time", 0.0f);
        SUITFloatData.Add("P_O2Pressure", 0.0f);
        SUITFloatData.Add("P_O2rate", 0.0f);
        SUITFloatData.Add("S_O2Time", 0.0f);
        SUITFloatData.Add("S_O2Pressure", 0.0f);
        SUITFloatData.Add("S_O2rate", 0.0f);

        SUITTimeLeftData.Add("O2TimeLeft", "----");

        SUITTimeLeftData.Add("H2OTimeLeft", "----");
        SUITFloatData.Add("H2O_LiquidPressure", 0.0f);
        SUITFloatData.Add("H2O_GasPressure", 0.0f);
        SUITFloatData.Add("H2O_Capacity", 0.0f);

        SUITTimeLeftData.Add("Battery_TimeLeft", "----");
        SUITFloatData.Add("Battery_Percentage", 0.0f);
        SUITFloatData.Add("Battery_Output", 0.0f);
        SUITFloatData.Add("Battery_Capacity", 0.0f);

        SUITFloatData.Add("Fan_Tachometer", 0.0f);
        SUITFloatData.Add("Temperature", 0.0f);
        SUITFloatData.Add("Suit_Pressure", 0.0f);
        SUITFloatData.Add("Sub_Pressure", 0.0f);

        SUITFloatData.Add("Heart_Rate", 0.0f);

    }

    void setO2Data(float p_o2time, float p_o2pressure, float p_o2rate,float s_o2timeleft, float s_o2pressure, float s_o2rate, string o2_timeleft)
    {
        SUITFloatData["P_O2Time"]=p_o2time;
        SUITFloatData["P_O2Pressure"] = p_o2pressure;
        SUITFloatData["P_O2rate"] = p_o2rate;
        SUITFloatData["S_O2Time"] = s_o2timeleft;
        SUITFloatData["S_O2Pressure"] = s_o2pressure;
        SUITFloatData["S_O2rate"] = s_o2rate;
        SUITTimeLeftData["O2TimeLeft"] = o2_timeleft;


    }

    void setH2OData(float h2o_lpressure, float h2o_gpressure, float h2o_cap, string h2o_timeleft)
    {
        SUITFloatData["H2O_LiquidPressure"] = h2o_lpressure;
        SUITFloatData["H2O_GasPressure"] = h2o_gpressure;
        SUITFloatData["H2O_Capacity"] = h2o_cap;
        SUITTimeLeftData["H2OTimeLeft"] = h2o_timeleft;
    }

    void setBatteryData(float batt_percent, float batt_output, float batt_cap, string batt_timeleft)
    {
        SUITFloatData["Battery_Percentage"] = batt_percent;
        SUITFloatData["Battery_Output"] = batt_output;
        SUITFloatData["Battery_Capacity"] = batt_cap;
        SUITTimeLeftData["Battery_TimeLeft"] = batt_timeleft;


    }

    void setIntegrityData(float fan_tach, float temp, float suit_pressure, float sub_Pressure)
    {
        SUITFloatData["Fan_Tachometer"] = fan_tach;
        SUITFloatData["Temperature"] = temp;
        SUITFloatData["Suit_Pressure"] = suit_pressure;
        SUITFloatData["Sub_Pressure"] = sub_Pressure;


    }

    void setHeartRate(float heart_rate)
    {
        SUITFloatData["Heart_Rate"] = heart_rate;

    }

    void checkAnomalies()
    {
        if (SUITFloatData["P_O2Pressure"] > 780 || SUITFloatData["P_O2Pressure"] < 770)
        {
            O2PressureLabel.color = new Color(1.0f, 0.0f, 0f, 1);
        }
        else
        {
            O2PressureLabel.color = new Color(0f, 0.8f, 0f, 1);
        }

        if (SUITFloatData["Battery_Capacity"] > 45 || SUITFloatData["Battery_Capacity"] < 60)
        {
            Batt_CapacityLabel.color = new Color(1.0f, 0.0f, 0f, 1);
        }
        else
        {
            Batt_CapacityLabel.color = new Color(0f, 0.8f, 0f, 1);
        }

        if (SUITFloatData["Fan_Tachometer"] > 40000 || SUITFloatData["Fan_Tachometer"] < 39000)
        {
            FanLabel.color = new Color(1.0f, 0.0f, 0f, 1);
        }
        else
        {
            FanLabel.color = new Color(0f, 0.8f, 0f, 1);
        }

        if (SUITFloatData["Suit_Pressure"] > 4.0 || SUITFloatData["Suit_Pressure"] < 3.92)
        {
            O2PressureLabel.color = new Color(1.0f, 0.0f, 0f, 1);
        }
        else
        {
            O2PressureLabel.color = new Color(0f, 0.8f, 0f, 1);
        }

        if (SUITFloatData["Heart_Rate"] > 93 || SUITFloatData["Heart_Rate"] < 85)
        {
            HeartRateLabel.color = new Color(1.0f, 0.0f, 0f, 1);
        }
        else
        {
            HeartRateLabel.color = new Color(0f, 0.8f, 0f, 1);
        }

        if (SUITFloatData["P_O2rate"] > 0.5 || SUITFloatData["P_O2rate"] < 0.6)
        {
            O2RateLabel.color = new Color(1.0f, 0.0f, 0f, 1);
        }
        else
        {
            O2RateLabel.color = new Color(0f, 0.8f, 0f, 1);
        }

    }

    void Update()
    {
        displaySUIT();
        checkAnomalies();
    }


    public void displaySUIT()
    {
        PrimaryOxygenInfo.text = "" + SUITFloatData["P_O2Time"];
        PrimaryOxygenPressure.text = "" + SUITFloatData["P_O2Pressure"];
        PrimaryOxygenRate.text = "" + SUITFloatData["P_O2rate"];
        SecondaryOxygenInfo.text = "" + SUITFloatData["S_O2Time"];
        SecondaryOxygenPressure.text = "" + SUITFloatData["S_O2Pressure"];
        SecondaryOxygenrate.text = "" + SUITFloatData["S_O2rate"];
        OxygenTimeLeftInfo.text = "" + SUITTimeLeftData["O2TimeLeft"];

        H2OTimeLeftInfo.text = "" + SUITTimeLeftData["H2OTimeLeft"];
        LiquidPressureInfo.text = "" + SUITFloatData["H2O_LiquidPressure"];
        GasPressureInfo.text = "" + SUITFloatData["H2O_GasPressure"];
        H2OCapacity.text = "" + SUITFloatData["H2O_Capacity"];
        HeartRateInfo.text = "" + SUITFloatData["Heart_Rate"];
        BatteryTimeLeftInfo.text = "" + SUITTimeLeftData["Battery_TimeLeft"];
        BatteryCapacityInfo.text = "" + SUITFloatData["Battery_Capacity"];
        BatteryPercentageTimeLeftInfo.text = "" + SUITFloatData["Battery_Percentage"];
        OutputInfo.text = "" + SUITFloatData["Battery_Output"];
        H2OOxygenTimeLeftInfo.text = "" + SUITTimeLeftData["H2OTimeLeft"];
        FanTachometerInfo.text = "" + SUITFloatData["Fan_Tachometer"];
        TemperatureInfo.text = "" + SUITFloatData["Temperature"];
        SuitPressureInfo.text = "" + SUITFloatData["Suit_Pressure"];
        SubPressureInfo.text = "" + SUITFloatData["Sub_Pressure"];

    //        public TMPro.TMP_Text PrimaryOxygenInfo;
    //public TMPro.TMP_Text PrimaryOxygenPressure;
    //public TMPro.TMP_Text PrimaryOxygenRate;
    //public TMPro.TMP_Text SecondaryOxygenInfo;
    //public TMPro.TMP_Text SecondaryOxygenPressure;
    //public TMPro.TMP_Text SecondaryOxygenrate;
    //public TMPro.TMP_Text OxygenTimeLeftInfo;

    //public TMPro.TMP_Text H2OTimeLeftInfo;
    //public TMPro.TMP_Text LiquidPressureInfo;
    //public TMPro.TMP_Text GasPressureInfo;
    //public TMPro.TMP_Text H2OCapacity;

    //public TMPro.TMP_Text HeartRateInfo;
    
    //public TMPro.TMP_Text BatteryTimeLeftInfo;
    //public TMPro.TMP_Text BatteryPercentageTimeLeftInfo;
    //public TMPro.TMP_Text OutputInfo;
    //public TMPro.TMP_Text H2OOxygenTimeLeftInfo;

    //public TMPro.TMP_Text FanTachometerInfo;
    //public TMPro.TMP_Text TemperatureInfo;
    //public TMPro.TMP_Text SuitPressureInfo;
    //public TMPro.TMP_Text SubPressureInfo;


    }
}
