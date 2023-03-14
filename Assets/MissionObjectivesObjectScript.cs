using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MissionObjectivesObjectScript : MonoBehaviour
{
    public GameObject buttonGO;
    private bool colorBool;
    //public TextMeshProUGUI buttonUI;
    //public GameObject EgressStatusGO;
    //public TextMeshProUGUI EgressStatus;
    //public GameObject SiteNavigationStatusGO;
    //public TextMeshProUGUI SiteNavigationStatus;
    //public GameObject GeologicalScanningStatusGO;
    //public GameObject GeologicalScanningStatus;
    //public GameObject ROVERStatusGO;
    //public TextMeshProUGUI ROVERStatus;
    //public GameObject ReturnNavigationStatusGO;
    //public TextMeshProUGUI ReturnNavigationStatus;
    // Start is called before the first frame update
    void Start()
    {
        colorBool = false;
        buttonGO.GetComponent<Image>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        colorBool = !colorBool;
        if (colorBool == true )
        {
            buttonGO.GetComponent<Image>().color = Color.green;
        }
        else
        {
            buttonGO.GetComponent<Image>().color = Color.red;
        }
        FindObjectOfType<MissionObjectivesDataHolder>().toggleStatus(buttonGO, colorBool);
    }

    private GameObject giveStatus()
    {
        return buttonGO;
    }

}
