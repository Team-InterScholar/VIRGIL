using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Position : MonoBehaviour
{
    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private GameObject User;

    private void Start()
    {
        initialPosition = gameObject.transform.position;
        FindObjectOfType<TelemetryStream>().UpdateOriginalPosition(initialPosition);
        User = GameObject.Find("User");
    }
    void Update()
    {
        currentPosition = User.transform.position;
        FindObjectOfType<TelemetryStream>().UpdateCurrentPosition(currentPosition);
    }


}
