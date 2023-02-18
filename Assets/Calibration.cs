using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calibration : MonoBehaviour
{
    Vector3 originalPosition;
    Vector3 currentPosition;
    void Start()
    {
        EventManager.CalibrationEvent += Instruction1;
    }

    private void Update()
    {
        currentPosition = FindObjectOfType<TelemetryStream>().getCurrentPosition();
    }


    private void Instruction1()
    {
        Debug.Log("Starting Calibration!");
        Debug.Log("Welcome to VIRGIL! To begin, let's calibrate the VISIONkit!");
        Debug.Log("Please move 1 meter to the right");
        StartCoroutine(test());

    }

    IEnumerator test()
    {
        Vector3 goalPosition = originalPosition + new Vector3(1.0f, 0.5f, 0.0f);
        Debug.Log(goalPosition);
        yield return new WaitForSeconds(8);
        originalPosition = FindObjectOfType<TelemetryStream>().getOriginalPosition();
        while (currentPosition.x < goalPosition.x)
        {
            Debug.Log("Please move 1 meter to the right");
            Debug.Log(currentPosition);
            yield return null;
        }
        Debug.Log("Thank you!");
    }
}
