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
        mainRowOfCards.SetActive(false);
    }

    public void OnButtonPressConnect()
    {

    }

    public void OnButtonPressSkip()
    {
        welcomeCard.SetActive(false);

        mainRowOfCards.SetActive(true);

        FindObjectOfType<IsFinalCardsShowing>().HouseKeeping();
        FindObjectOfType<ButtonBehaviour>().HouseKeeping();


    }

}
