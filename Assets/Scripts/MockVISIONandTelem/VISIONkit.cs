using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VISIONkit : MonoBehaviour
{
    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private float currentAngleY;
    private float initialAngleY;
    private GameObject User;


    private void Start()
    {
        User = GameObject.Find("User");
        initialPosition = User.transform.position;
        initialAngleY = User.transform.localRotation.eulerAngles.y;
        FindObjectOfType<TelemetryStream>().updateInitialPosition(initialPosition);
        FindObjectOfType<TelemetryStream>().updateInitialAngleY(initialAngleY);
    }
    void Update()
    {
        currentPosition = User.transform.position;
        currentAngleY = User.transform.localRotation.eulerAngles.y;
        FindObjectOfType<TelemetryStream>().updateCurrentPosition(currentPosition);
        FindObjectOfType<TelemetryStream>().updateCurrentAngleY(currentAngleY);
    }


}
