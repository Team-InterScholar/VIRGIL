using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InformationPanelScript : MonoBehaviour
{
    public GameObject MOPanel;
    public GameObject spectroPanel;


    public bool isShowingMO;
    public bool isShowingSpectro;
    // Start is called before the first frame update
    void Start()
    {
        isShowingMO = false;
        isShowingSpectro = false;
        MOPanel.SetActive(false);
        spectroPanel.SetActive(false);
    }

    public void OnButtonPressMO()
    {
        isShowingMO = !isShowingMO;
        if(isShowingSpectro == true)
        {
            isShowingSpectro = false;
            spectroPanel.SetActive(isShowingSpectro);
            MOPanel.SetActive(isShowingMO);
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
        if (isShowingMO == true)
        {
            isShowingMO = false;
            MOPanel.SetActive(isShowingMO);
            spectroPanel.SetActive(isShowingSpectro);
        }
        else
        {
            spectroPanel.SetActive(isShowingSpectro);
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
