using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action CalibrationEvent1;
    public static event Action CalibrationEvent2;

    bool passedCal1 = false;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if (passedCal1 == false)
            {
                passedCal1 = true;
                if (CalibrationEvent1 != null)
                    CalibrationEvent1();
            }
            else
            {
                if (CalibrationEvent2 != null)
                    CalibrationEvent2();
            }
        }
    }


}
