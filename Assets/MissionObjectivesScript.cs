using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.Composites;
using TMPro;

public class MissionObjectivesScript : MonoBehaviour
{
    public GameObject importedButton;
    public TextMeshProUGUI EVALabel;
    private Button button;
    private Dictionary<string, bool> missionObjectives;
    // Start is called before the first frame update
    void Start()
    {
        importedButton = FindObjectOfType<EVAScript>().giveMission();
        print("TEST");
        EVALabel = FindObjectOfType<EVAScript>().giveLabel();
        button = importedButton.GetComponent<Button>();

        button.onClick.AddListener(ButtonPressed);
        missionObjectives = new Dictionary<string, bool>();
        missionObjectives.Add("Calibration", false);
        missionObjectives.Add("Egress", false);
        missionObjectives.Add("Site Navigation", false);
        missionObjectives.Add("Geological Scanning", false);
        missionObjectives.Add("ROVER", false);
        missionObjectives.Add("Return Navigation", false);

    }

    public void ButtonPressed()
    {
        EVALabel.GetComponent<TextMeshProUGUI>().text = "" +
            "Calibration: " + missionObjectives["Calibration"] + "\n" +
            "Egress: " + missionObjectives["Egress"] + "\n" +
            "Site Navigation: " + missionObjectives["Site Navigation"] + "\n" +
            "Geological Scanning: " + missionObjectives["Geological Scanning"] + "\n" +
            "ROVER: " + missionObjectives["ROVER"] + "\n" +
            "Return Navigation: " + missionObjectives["Return Navigation"] + "\n";

        print("test");
    }


}
