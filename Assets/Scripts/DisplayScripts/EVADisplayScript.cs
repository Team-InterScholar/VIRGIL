using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EVADisplayScript : MonoBehaviour
{
    public GameObject telemPanel;
    public GameObject objectivesPanel;
    public GameObject UIAPanel;
    public GameObject scansPanel;
    // Start is called before the first frame update
    void Start()
    {
        telemPanel.SetActive(true);
        objectivesPanel.SetActive(false);
        UIAPanel.SetActive(false);
        scansPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        print(this.name + "\n");
        if (this.name == "TelemetryBtn")
        {
            telemPanel.SetActive(true);
            objectivesPanel.SetActive(false);
            UIAPanel.SetActive(false);
            scansPanel.SetActive(false);
        }
        else if (this.name == "ObjectivesBtn")
        {
            telemPanel.SetActive(false);
            objectivesPanel.SetActive(true);
            UIAPanel.SetActive(false);
            scansPanel.SetActive(false);
        }
        else if (this.name == "UIABtn")
        {
            telemPanel.SetActive(false);
            objectivesPanel.SetActive(false);
            UIAPanel.SetActive(true);
            scansPanel.SetActive(false);
        }
        else if (this.name == "SpectroBtn")
        {
            telemPanel.SetActive(false);
            objectivesPanel.SetActive(false);
            UIAPanel.SetActive(false);
            scansPanel.SetActive(true);
        }

    }
}
