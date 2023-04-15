using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsDataHolderScript : MonoBehaviour
{
    public Dictionary<string, bool> alertsBooleans;
    void Start()
    {
        alertsBooleans = new Dictionary<string, bool>();
        alertsBooleans.Add("heartRate", false);
        alertsBooleans.Add("suitPressure", false);
        alertsBooleans.Add("fan", false);
        alertsBooleans.Add("o2Pressure", false);
        alertsBooleans.Add("o2Rate", false);
        alertsBooleans.Add("batteryCapacity", false);

    }


    public Dictionary<string, bool> GetAlertsBooleans()
    {
        return alertsBooleans;
    }

    public void setUIABoolean(string str, bool newStatus)
    {
        alertsBooleans[str] = newStatus;
    }


}
