using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action EVAEvent;


    private void Start()
    {
        //print("Welcome to VIRGIL! To begin, let's make sure the VISIONkit is working");
        //StartCoroutine(doCalibration());
        StartCoroutine(lockCursor());
        StartCoroutine(doEVACard());
    }
    private void Update()
    {
    }

    private IEnumerator lockCursor()
    {
        while (true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Cursor.visible = !Cursor.visible;
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            yield return null;
        }
    }

    private IEnumerator doEVACard()
    {
        while(true)
        {
            while (Input.GetKeyUp("space") != true)
            {

                yield return null;
            }
            if (EVAEvent != null)
            {
                EVAEvent();
            }
            yield return null;
        }
    }
}
