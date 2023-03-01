using Mono.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class Card_EVA : MonoBehaviour
{
    bool isCardOpen;
    bool isFirstTime;
    void Start()
    {
        EventManager.EVAEvent += Test;
        HouseKeeping();

    }

    private void Update()
    {
        if (isCardOpen == true)
        {
            print("EVA CARD is open");
        }
    }



    private void HouseKeeping()
    {
        isCardOpen = false;
        // CardElements cardElement = new CardElements();
        // MissionObjectives missionObject = new MissionObjectives();
        // UIAStatus uiaObject = new UIAStatus();
        // SpectrometerScans spectrometerObject = new SpectrometerScans();
    }

    void Test()
    {
        isCardOpen = !isCardOpen;
    }
}
