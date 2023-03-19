using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EVAScript : MonoBehaviour
{
    public GameObject EVAButton;
    public GameObject canvas;

    public GameObject elementsPanel;
    public GameObject informationPanel;
    public TextMeshProUGUI textUIA;
    private Dictionary<string, bool> UIABooleans;

    public GameObject MissionObjectivesButton;
    public GameObject SpectrometerDataButton;

    private Dictionary<string, bool> missionObjectives;

    private bool isShowing;


    void Start()
    {
        isShowing = false;
        elementsPanel.SetActive(isShowing);
        informationPanel.SetActive(isShowing);
        //MissionObjectivesButton.SetActive(false);
        //UIAStatusButton.SetActive(false);
        //SpectrometerDataButton.SetActive(false);

    }

    void Update()
    {
    
    }



    public void enableEVACARD()
    {
        EVAButton.SetActive(true);
    }

    public void ButtonPressed()
    {
        isShowing = !isShowing;
        elementsPanel.SetActive(isShowing);
        informationPanel.SetActive(isShowing); 
        if (isShowing == true)
        {
            UIABooleans = FindObjectOfType<UIADataHolderScript>().GetUIABooleans();
            textUIA.GetComponent<TextMeshProUGUI>().text = "" +
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
}
