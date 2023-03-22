using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIADataHolderScript : MonoBehaviour
{
    public Dictionary<string, bool> UIABooleans;
    public TextMeshProUGUI UIALabel;
    private bool isShowing;

    // waste port
    // emu2 supply press
    // Start is called before the first frame update
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


    public void OnPressed()
    {
        if (isShowing == true)
        {
            UIALabel.GetComponent<TextMeshProUGUI>().text = "" +
            "EV1" + UIABooleans["EV1"] + "\n" +
            "EV2" + UIABooleans["EV2"] + "\n" +
            "EMU1" + UIABooleans["EMU1"] + "\n" +
            "EMU2" + UIABooleans["EMU2"] + "\n" +
            "Supply Switch" + UIABooleans["supplySwitch"] + "\n" +
            "Waste Switch" + UIABooleans["wasteSwitch"] + "\n" +
            "EMU" + UIABooleans["EMU"] + "\n" +
            "EMU Power" + UIABooleans["emuPower"] + "\n" +
            "Depress Pump" + UIABooleans["depressPump"] + "\n" +
            "";
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

}
