using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    Vector3 initialPosition;
    Vector3 currentPosition;
    float initialAngleY;
    float currentAngleY;
    void Start()
    {
        initialPosition = FindObjectOfType<TelemetryStream>().getInitialPosition();
        initialAngleY = FindObjectOfType<TelemetryStream>().getInitialAngleY();
        EventManager.CalibrationEvent1 += Instruction1;
        EventManager.CalibrationEvent2 += Instruction2;
    }

    private void Update()
    {
        currentPosition = FindObjectOfType<TelemetryStream>().getCurrentPosition();
        currentAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
    }


    private void Instruction1()
    {
        StartCoroutine(showInstructions1());
        StartCoroutine(calibration1());
    }

    private void Instruction2()
    {
        StartCoroutine(showInstructions2());
        StartCoroutine(calibration2());
    }

    IEnumerator calibration1()
    {
        Vector3 goalPosition = initialPosition + new Vector3(1.0f, 0.5f, 0.0f);
        initialPosition = FindObjectOfType<TelemetryStream>().getInitialPosition();
        while (currentPosition.x < goalPosition.x)
        {
            yield return null;
        }
        Debug.Log("One meter walked. Thank you!");
        yield return new WaitForSeconds(3);
        Debug.Log("Please right click for further instructions!");
    }

    IEnumerator calibration2()
    {
        float goalAngle = initialAngleY + (90);
        while (currentAngleY < goalAngle)
        {
            yield return null;
        }
        Debug.Log("Looked 90 degrees to the right. Thank you!");
  
    }

    IEnumerator showInstructions1()
    {
        Debug.Log("Starting Calibration!");
        yield return new WaitForSeconds(3);
        Debug.Log("Welcome to VIRGIL! To begin, let's calibrate the VISIONkit!");
        yield return new WaitForSeconds(5);
        Debug.Log("Please move 1 meter forward");
    }

    IEnumerator showInstructions2()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Please look 90 degrees to your right");
    }
}
