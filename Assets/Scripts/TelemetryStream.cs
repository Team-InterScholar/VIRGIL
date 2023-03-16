using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryStream : MonoBehaviour
{
    private Vector3 currentPosition;
    private Vector3 initialPosition;
    private float currentAngleY;
    private float initialAngleY;


    public float getInitialAngleY()
    {
        return initialAngleY;
    }

    public float getCurrentAngleY()
    {
        return currentAngleY;
    }

    public void updateCurrentAngleY(float incomingAngleY)
    {
        currentAngleY = incomingAngleY;
    }

    public void updateInitialAngleY(float incomingAngleY)
    {
        initialAngleY = incomingAngleY;
    }
    public Vector3 getInitialPosition()
    {
        return initialPosition;
    }

    public Vector3 getCurrentPosition()
    {
        return currentPosition;
    }

    public void updateCurrentPosition(Vector3 incomingPosition)
    {
        currentPosition = incomingPosition;
    }
    public void updateInitialPosition(Vector3 incomingPosition)
    {
        initialPosition = incomingPosition;
    }
}
