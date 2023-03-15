using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIADataHolderScript : MonoBehaviour
{
    public Dictionary<string, bool> UIABooleans;
    public TextMeshProUGUI UIALabel;
    public GameObject UIALabelGO;
    private bool isShowing;

    // waste port
    // emu2 supply press
    // Start is called before the first frame update
    void Start()
    {
        UIABooleans = new Dictionary<string, bool>();
        UIABooleans.Add("EV1", false);
        UIABooleans.Add("EV2", false);
        UIABooleans.Add("EMU1", false);
        UIABooleans.Add("EMU2", false);
        UIABooleans.Add("supplySwitch", false);
        UIABooleans.Add("wasteSwitch", false);
        UIABooleans.Add("EMU", false);
        UIABooleans.Add("emuPower", false);
        UIABooleans.Add("depressPump", false);


    }


    public void OnPressed()
    {
        isShowing = !isShowing;

        if (isShowing == true)
        {
            UIALabelGO.SetActive(true);
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
        else
        {
            UIALabelGO.SetActive (false);
        }
   

    }

}
