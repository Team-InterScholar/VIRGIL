using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WelcomeScript : MonoBehaviour
{
    public GameObject welcomeCard;
    public GameObject mainRowOfCards;
    public GameObject partingMessage;

    bool isConnectedToTelemetryStream;

    void Start()
    {
        print("WelcomeScript is starting");
        mainRowOfCards.SetActive(false);
        partingMessage.SetActive(false);
    }

    public void OnButtonPressedConnect()
    {
        StartCoroutine(wait());

 
    }

    public void exitButton()
    {
        partingMessage.SetActive(false);
    }

    IEnumerator wait()
    {
        FindObjectOfType<MapOutput>().HouseKeeping();
        FindObjectOfType<roverPointControl>().HouseKeeping();
        FindObjectOfType<AlertsDataHolderScript>().HouseKeeping();
        FindObjectOfType<MissionObjectivesDataHolder>().HouseKeeping();
        FindObjectOfType<SpectrometerDataHolderScript>().HouseKeeping();
        FindObjectOfType<SUITDataHolder>().HouseKeeping();
        FindObjectOfType<UIADataHolderScript>().HouseKeeping();

        yield return new WaitForSeconds(3);
        if (FindObjectOfType<ConnScript>().getIsTelemOn())
        {

            welcomeCard.SetActive(false);
            mainRowOfCards.SetActive(true);
            FindObjectOfType<IsFinalCardsShowing>().HouseKeeping();
            FindObjectOfType<ButtonBehaviour>().HouseKeeping();

            //mainRowOfCards.SetActive(true);

            //FindObjectOfType<MapOutput>().HouseKeeping();
            //FindObjectOfType<roverPointControl>().HouseKeeping();
            //FindObjectOfType<AlertsDataHolderScript>().HouseKeeping();
            //FindObjectOfType<MissionObjectivesDataHolder>().HouseKeeping();
            //FindObjectOfType<SpectrometerDataHolderScript>().HouseKeeping();
            //FindObjectOfType<SUITDataHolder>().HouseKeeping();
            //FindObjectOfType<UIADataHolderScript>().HouseKeeping();
            //FindObjectOfType<IsFinalCardsShowing>().HouseKeeping();
            //FindObjectOfType<ButtonBehaviour>().HouseKeeping();


        }
        else
        {

        }

    }

    IEnumerator waitSkip()
    {
        yield return new WaitForSeconds(3);
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

        partingMessage.SetActive(true);




    }

}
