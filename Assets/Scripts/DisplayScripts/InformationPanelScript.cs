using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationPanelScript : MonoBehaviour
{
    public GameObject MOPanel;
    public GameObject spectroPanel;
    public GameObject telemPanel;


    public bool isShowingMO;
    public bool isShowingSpectro;
    public bool isShowingTelem;
    // Start is called before the first frame update
    void Start()
    {
        isShowingMO = false;
        isShowingSpectro = false;
        isShowingTelem = false;
        MOPanel.SetActive(false);
        spectroPanel.SetActive(false);
        telemPanel.SetActive(false);

    }

    public void OnButtonPressMO()
    {
        isShowingMO = !isShowingMO;
        if (isShowingSpectro == true || isShowingTelem == true)
        {
            isShowingSpectro = false;
            isShowingTelem = false;
            spectroPanel.SetActive(isShowingSpectro);
            MOPanel.SetActive(isShowingMO);
            telemPanel.SetActive(isShowingTelem);
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
        }
        else
        {
            MOPanel.SetActive(isShowingMO);
        }
    }
    public void OnButtonPressSpectro()
    {
        isShowingSpectro = !isShowingSpectro;
        if (isShowingMO == true || isShowingTelem == true)
        {
            isShowingMO = false;
            isShowingTelem = false;
            MOPanel.SetActive(isShowingMO);
            spectroPanel.SetActive(isShowingSpectro);
            telemPanel.SetActive(isShowingTelem);
        }
        else
        {
            spectroPanel.SetActive(isShowingSpectro);
        }
    }
    public void OnButtonPressTelem()
    {
        isShowingTelem = !isShowingTelem;
        if (isShowingMO == true || isShowingSpectro == true)
        {
            isShowingMO = false;
            isShowingSpectro = false;
            MOPanel.SetActive(isShowingMO);
            spectroPanel.SetActive(isShowingSpectro);
            telemPanel.SetActive(isShowingTelem);
        }
        else
        {
            telemPanel.SetActive(isShowingTelem);
        }


    }








    public void MOButtonsColor()
    {
        foreach (KeyValuePair<GameObject, bool> item in FindObjectOfType<MissionObjectivesDataHolder>().GetMissionObjectives())
        {
            if (item.Value == true)
            {
                print("detected");
                item.Key.GetComponent<Image>().color = Color.green;
            }
            else
            {
                item.Key.GetComponent<Image>().color = Color.red;
            }
        }
    }


}
