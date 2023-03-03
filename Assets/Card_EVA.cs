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
        if(isCardOpen == true)
        {
            print("EVA Card is Open");
        }
        else
        {
            print("EVA Card is closed");
        }
    }
}
