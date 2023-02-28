using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action CalibrationEvent1;
    public static event Action CalibrationEvent2;


    private void Start()
    {
        print("Welcome to VIRGIL! To begin, let's make sure the VISIONkit is working");
        StartCoroutine(doCalibration());
    }
    private void Update()
    {

    }

    private IEnumerator doCalibration()
    {
        bool passedCal1 = false;


        yield return new WaitForSeconds(3);
        print("Starting Calibration");
        yield return new WaitForSeconds(3);
        print("Please right click to continue ");
        while(Input.GetMouseButtonDown(1) != true)
        {
            Input.GetMouseButtonDown(1);
            yield return null;
        }

        if (CalibrationEvent1 != null)
        {
            CalibrationEvent1();
            bool sentinel = false;
            while( sentinel == false)
            {
                sentinel = FindObjectOfType<Calibration>().getBool1();
                yield return null;
            }
            passedCal1 = true;
        }
        yield return new WaitForSeconds(3);
        if (passedCal1 == true)
        {
            if(CalibrationEvent2 != null)
            {
                CalibrationEvent2();
                bool sentinel = false;
                while (sentinel == false)
                {
                    sentinel = FindObjectOfType<Calibration>().getBool2();
                    yield return null;
                }
            }
        }
        yield return new WaitForSeconds(3);
        print("Calibration completed!");
    }



}
