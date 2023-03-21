using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject finalCard;
    private bool isShowing;

    void Start()
    {
        isShowing = false;
        finalCard.SetActive(isShowing);
    }

    public void OnButtonPress()
    {
        isShowing = !isShowing;
        finalCard.SetActive(isShowing);
    }
    public void onButtonPressEVA()
    {
        foreach (KeyValuePair<GameObject, bool> item in FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives())
        {
            if (item.Value == true)
            {
                item.Key.GetComponent<Image>().color = Color.green;
            }
            else
            {
                item.Key.GetComponent<Image>().color = Color.red;
            }
        }

        GameObject confirmButton = GameObject.Find("ConfirmButton");
        if(confirmButton != null)
        {
            confirmButton.GetComponent<Button>().interactable = false;        
        }
        else
        {

        }
        // GameObject.Find("ConfirmButton").GetComponent<Button>().interactable = false;

        GameObject uiaInfo = GameObject.Find("UIAInfo");
        if (uiaInfo != null)
        {
            Dictionary<string, bool> UIABooleans = FindObjectOfType<UIADataHolderScript>().GetUIABooleans();
            uiaInfo.GetComponent<TextMeshProUGUI>().text = "" +
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
        else
        {

        }

    }
}
