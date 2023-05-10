using Microsoft.MixedReality.Toolkit.SpatialManipulation;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject finalCard;
    private bool isShowing;
    private GameObject currentPanel;

    public GameObject emptyObjectButtons;


    void Start()
    {
        isShowing = false;
        finalCard.SetActive(isShowing);
    }

    public void OnButtonPress()
    {
        isShowing = !isShowing;
        finalCard.SetActive(isShowing);
        emptyObjectButtons.GetComponent<IsFinalCardsShowing>().setMaxView();

    }

    public bool getIsShowing()
    {
        return isShowing;
    }

    //public void OnButtonExit()
    //{
    //    Invoke("OnButtonPress",0.5f);
    //}

    //public void OnButtonPressTest()
    //{
        
    //    if (currentPanel == null)
    //    {
    //        currentPanel = GameObject.Find("telemPanel");
    //    }
    //    else
    //    {
    //        if (this.name == "TelemetryBtn")
    //        {
    //            currentPanel = GameObject.Find("telemPanel");
    //        } else if (this.name == "ObjectivesBtn") {
    //            currentPanel = GameObject.Find("objectivesPanel");
    //        } else if (this.name == "UIABtn")
    //        {
    //            currentPanel = GameObject.Find("UIAPanel");
    //        } else if (this.name == "SpectroBtn")
    //        {
    //            currentPanel = GameObject.Find("scansPanel");
    //        }
    //    }

    //    currentPanel.SetActive(true);

    //}

    public void onButtonPressEVA()
    {
        //foreach (KeyValuePair<GameObject, bool[]> item in FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives())
        //{
        //    if (item.Value[1] == true)
        //    {
        //        item.Key.GetComponent<Image>().color = Color.green;
        //    }
        //    else
        //    {
        //        item.Key.GetComponent<Image>().color = Color.red;
        //    }
        //}

        foreach (KeyValuePair<GameObject, bool[]> item in FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives())
        {
            if (item.Value[0] == true)
            {
                item.Key.GetComponent<Image>().color = Color.yellow;
            }
            else
            {
                if (item.Value[1] == true)
                {
                    item.Key.GetComponent<Image>().color = Color.green;
                }
                else
                {
                    item.Key.GetComponent<Image>().color = Color.red;
                }
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
        GameObject selectButton = GameObject.Find("CurrentObjButton");
        if (confirmButton != null)
        {
            selectButton.GetComponent<Button>().interactable = false;
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
        }
        else
        {

        }

    }

    public void OnButtonPressSUIT()
    {
        //GameObject.Find("BiometricsInfo").GetComponent<TextMeshProUGUI>().text = "test";
    }
}
