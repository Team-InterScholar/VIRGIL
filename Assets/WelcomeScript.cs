using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScript : MonoBehaviour
{
    public GameObject welcomeCard;
    public GameObject mainRowOfCards;

    bool isConnectedToTelemetryStream;

    void Start()
    {
        print("WelcomeScript is starting");
        mainRowOfCards.SetActive(false);
    }

    public void OnButtonPressedConnect()
    {
        StartCoroutine(wait());
 
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3);
        if (FindObjectOfType<ConnScript>().getIsTelemOn())
        {
            welcomeCard.SetActive(false);

            mainRowOfCards.SetActive(true);

            FindObjectOfType<MapOutput>().HouseKeeping();
            FindObjectOfType<roverPointControl>().HouseKeeping();
            FindObjectOfType<AlertsDataHolderScript>().HouseKeeping();
            FindObjectOfType<MissionObjectivesDataHolder>().HouseKeeping();
            FindObjectOfType<SpectrometerDataHolderScript>().HouseKeeping();
            FindObjectOfType<SUITDataHolder>().HouseKeeping();
            FindObjectOfType<UIADataHolderScript>().HouseKeeping();
            FindObjectOfType<IsFinalCardsShowing>().HouseKeeping();
            FindObjectOfType<ButtonBehaviour>().HouseKeeping();
        }
        else
        {

        }
    }

    public void OnButtonPressSkip()
    {
        welcomeCard.SetActive(false);

        mainRowOfCards.SetActive(true);

        FindObjectOfType<ConnScript>().setIsTelemOn();

        FindObjectOfType<MapOutput>().HouseKeeping();
        FindObjectOfType<roverPointControl>().HouseKeeping();
        FindObjectOfType<AlertsDataHolderScript>().HouseKeeping();
        FindObjectOfType<MissionObjectivesDataHolder>().HouseKeeping();
        FindObjectOfType<SpectrometerDataHolderScript>().HouseKeeping();
        FindObjectOfType<SUITDataHolder>().HouseKeeping();
        FindObjectOfType<UIADataHolderScript>().HouseKeeping();
        FindObjectOfType<IsFinalCardsShowing>().HouseKeeping();
        FindObjectOfType<ButtonBehaviour>().HouseKeeping();



    }

}
