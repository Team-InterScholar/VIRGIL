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
    private GameObject MissionObjectives;
    private GameObject UIAStatus;
    private GameObject SpectrometerData;
    private bool isShowing;
    // Start is called before the first frame update
    void Start()
    {
        
        myLabel.GetComponent<TextMeshProUGUI>().text = "";

        MissionObjectives = Instantiate(button) as GameObject;
        MissionObjectives.transform.SetParent(canvas.transform, false);
        MissionObjectives.transform.Translate(0.5f,0.1f, 0.0f);
        MissionObjectives.GetComponentInChildren<TextMeshProUGUI>().text = "Mission Objectives";
        MissionObjectives.SetActive(false);

        UIAStatus = Instantiate(button) as GameObject;
        UIAStatus.transform.SetParent(canvas.transform, false);
        UIAStatus.transform.Translate(0.5f, -0.1f, 0.0f);
        UIAStatus.GetComponentInChildren<TextMeshProUGUI>().text = "UIA Status";
        UIAStatus.SetActive(false);

        SpectrometerData = Instantiate(button) as GameObject;
        SpectrometerData.transform.SetParent(canvas.transform, false);
        SpectrometerData.transform.Translate(0.5f, -0.3f, 0.0f);
        SpectrometerData.GetComponentInChildren<TextMeshProUGUI>().text = "Spectrometer Data";
        SpectrometerData.SetActive(false);
        
    }

    public void enableEVACARD()
    {
        EVAButton.SetActive(true);
    }

    public void ButtonPressed()
    {
        print(isShowing);
        isShowing = !isShowing;
        MissionObjectives.SetActive(isShowing);
        UIAStatus.SetActive(isShowing);
        SpectrometerData.SetActive(isShowing);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
