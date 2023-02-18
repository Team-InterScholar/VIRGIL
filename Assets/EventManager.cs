using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action CalibrationEvent;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked!");

            if (CalibrationEvent != null)
                CalibrationEvent();
        }
    }


}
