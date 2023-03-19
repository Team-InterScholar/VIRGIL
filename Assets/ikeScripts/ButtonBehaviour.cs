using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject finalCard;
    private bool isShowing;

    void Start()
    {
        isShowing = false;
        finalCard.SetActive(isShowing);
    }

    public void OnButtonPress() 
    {
        isShowing = !isShowing;
        finalCard.SetActive(isShowing);
    }
}
