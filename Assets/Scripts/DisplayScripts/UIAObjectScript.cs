using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAObjectScript : MonoBehaviour
{
    public TextMeshProUGUI labelUIA;
    public GameObject refreshButton;
    public TextMeshProUGUI refreshLabel;
    private string lastRefreshed;
    private Dictionary<string, bool> UIABooleans;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnButtonPressed()
    {
            
        UIABooleans = FindObjectOfType<UIADataHolderScript>().GetUIABooleans();
        labelUIA.GetComponent<TextMeshProUGUI>().text = "" +
        "EMU1        " + UIABooleans["EMU1"] + "\n" +
        "EMU2        " + UIABooleans["EMU2"] + "\n" +
        "O2 Supply Pressure 1" + UIABooleans["O2 Supply Pressure 1"] + "\n" +
        "O2 Supply Pressure 2" + UIABooleans["O2 Supply Pressure 2"] + "\n" +
        "O2 Supply Pressure Out 1  " + UIABooleans["O2 Supply Pressure Out 1"] + "\n" +
        "O2 Supply Pressure Out 2    " + UIABooleans["O2 Supply Pressure Out 2"] + "\n" +
        "EV1 Supply        " + UIABooleans["EV1 Supply"] + "\n" +
        "EV2 Supply " + UIABooleans["EV2 Supply"] + "\n" +
        "EV1 Waste   " + UIABooleans["EV1 Waste"] + "\n" +
        "EV2 Waste   " + UIABooleans["EV2 Waste"] + "\n" +
        "EMU1 O2        " + UIABooleans["EMU1 O2"] + "\n" +
        "EMU2 O2        " + UIABooleans["EMU2 O2"] + "\n" +
        "O2 Vent        " + UIABooleans["O2 Vent"] + "\n" +
        "Depress Pump        " + UIABooleans["Depress Pump"] + "\n" +
        "";

        refreshLabel.GetComponent<TextMeshProUGUI>().text = "Last refreshed at: " + lastRefreshed;

    }

    public void setLastRefreshTime(string str)
    {
        lastRefreshed = str;
    }
}
