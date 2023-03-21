using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIAObjectScript : MonoBehaviour
{
    public TextMeshProUGUI labelUIA;
    public GameObject refreshButton;
    private Dictionary<string, bool> UIABooleans;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnButtonPressed()
    {

            UIABooleans = FindObjectOfType<UIADataHolderScript>().GetUIABooleans();
            labelUIA.GetComponent<TextMeshProUGUI>().text = "" +
            "EV1        " + UIABooleans["EV1"] + "\n" +
            "EV2        " + UIABooleans["EV2"] + "\n" +
            "EMU1       " + UIABooleans["EMU1"] + "\n" +
            "EMU2       " + UIABooleans["EMU2"] + "\n" +
            "Supply Switch  " + UIABooleans["supplySwitch"] + "\n" +
            "Waste Switc    " + UIABooleans["wasteSwitch"] + "\n" +
            "EMU        " + UIABooleans["EMU"] + "\n" +
            "EMU Power  " + UIABooleans["emuPower"] + "\n" +
            "Depress Pump   " + UIABooleans["depressPump"] + "\n" +
            "";

    }
}
