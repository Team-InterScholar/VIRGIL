using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
/**********************************/
/*       Calibration Script
 * ********************************
 * This script will ask the User to
 * do two actions:
 *   1. Walk 1 meter in the x 
 *   direction.
 *   
 *   2. Look 90 degrees to 
 *   the right.
 *   
 * The script will then retrieve 
 * data from the telemetry stream
 * to verify that VISION is working.
 * 
 * Any line with "myLabel.GetComponent<TextMeshProUGUI>().text " 
 * may be replaced with Isaac's 
 * display.
 * 
 * 
 * 
 * 
/*                               */
/**********************************/
public class CalibrationScript : MonoBehaviour
{
    public TextMeshProUGUI myLabel;

    Vector3 initialPosition;
    Vector3 currentPosition;
    float initialAngleY;
    float currentAngleY;
    bool sentinel1;
    bool sentinel2;
    // Start is called before the first frame update
    void Start()
    {
        myLabel.GetComponent<TextMeshProUGUI>().text = "Welcome to VIRGIL! To begin, " +
            "please press the button to start Calibration";
    }

    public void ButtonPressed()
    {
        StartCoroutine(doCalibration());

    }




    private IEnumerator doCalibration()
    {

        myLabel.GetComponent<TextMeshProUGUI>().text = "Starting Calibration...";
        yield return new WaitForSeconds(3);
        Instruction1();
        while(sentinel1 == false)
        {
            sentinel1 = getBool1();
            yield return null;
        }
        yield return new WaitForSeconds(3);
        Instruction2();
        while (sentinel2 == false)
        {
            sentinel2 = getBool2();
            yield return null;
        }


        yield return new WaitForSeconds(3);
        myLabel.GetComponent<TextMeshProUGUI>().text = "Calibration completed!";
        
    }


    // Each instruction will display instructions on
    // the screen and then execute data verification.
    private void Instruction1()
    {
        sentinel1 = false;
        myLabel.GetComponent<TextMeshProUGUI>().text = "Please move 1 meter forward";
        StartCoroutine(calibration1());
    }

    private void Instruction2()
    {
        myLabel.GetComponent<TextMeshProUGUI>().text = "Please look 90 degrees to your right";
        StartCoroutine(calibration2());
    }

    // calibration1 and calibration2 
    IEnumerator calibration1()
    {
        initialPosition = FindObjectOfType<TelemetryStream>().getCurrentPosition();
        Vector3 goalPosition = initialPosition + new Vector3(1.0f, 0.5f, 0.0f);
        currentPosition.x = FindObjectOfType<TelemetryStream>().getCurrentPosition().x;
        while (currentPosition.x < goalPosition.x)
        {
            currentPosition.x = FindObjectOfType<TelemetryStream>().getCurrentPosition().x;
            yield return null;
        }
        sentinel1 = true;
        myLabel.GetComponent<TextMeshProUGUI>().text = "One meter walked. Thank you!";
        print("test");
        yield return new WaitForSeconds(3);
    }

    public bool getBool1()
    {
        return sentinel1;
    }
    public bool getBool2()
    {
        return sentinel2;
    }


    IEnumerator calibration2()
    {
        initialAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
        float goalAngle = initialAngleY + (90);
        currentAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
        while (currentAngleY < goalAngle)
        {
            currentAngleY = FindObjectOfType<TelemetryStream>().getCurrentAngleY();
            yield return null;
        }
        sentinel2 = true;
        myLabel.GetComponent<TextMeshProUGUI>().text = "Looked 90 degrees to the right. Thank you!";

    }
}
