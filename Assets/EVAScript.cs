using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EVAScript : MonoBehaviour
{
    public TextMeshProUGUI myLabel;
    public GameObject EVAButton;
    public GameObject button;
    public GameObject canvas;

    public GameObject MissionObjectivesButton;
    public GameObject UIAStatusButton;
    public GameObject SpectrometerDataButton;

    private Dictionary<string, bool> missionObjectives;

    private bool isShowing;


    void Start()
    {
        
        myLabel.GetComponent<TextMeshProUGUI>().text = "";

        MissionObjectivesButton.SetActive(false);
        UIAStatusButton.SetActive(false);
        SpectrometerDataButton.SetActive(false);


    }

    void Update()
    {
    
    }


    public TextMeshProUGUI giveLabel()
    {
        return myLabel;
    }

    public void enableEVACARD()
    {
        EVAButton.SetActive(true);
    }

    public void ButtonPressed()
    {
        print(isShowing);
        isShowing = !isShowing;
        MissionObjectivesButton.SetActive(isShowing);
        UIAStatusButton.SetActive(isShowing);
        SpectrometerDataButton.SetActive(isShowing);
        myLabel.enabled = isShowing;

    }
}
