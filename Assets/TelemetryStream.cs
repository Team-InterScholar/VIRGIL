using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelemetryStream : MonoBehaviour
{
    Vector3 currentPosition;
    Vector3 originalPosition;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public Vector3 getOriginalPosition()
    {
        return originalPosition;
    }

    public Vector3 getCurrentPosition()
    {
        return currentPosition;
    }

    public void UpdateCurrentPosition(Vector3 incomingPosition)
    {
        currentPosition = incomingPosition;
    }
    public void UpdateOriginalPosition(Vector3 incomingPosition)
    {
        originalPosition = incomingPosition;
    }
}
