using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject card;
    public GameObject elements;
    public GameObject info;
    private bool isShowing;

    void Start()
    {
        isShowing = false;
        elements.SetActive(false);
        info.SetActive(false);
    }

    public void OnButtonPress() 
    {
        if (card.activeInHierarchy == true)
            card.SetActive(false);
        else
            card.SetActive(true);
    }

    public void EVAOnButtonPress()
    {
        isShowing = !isShowing;
        elements.SetActive(isShowing);
        info.SetActive(isShowing);
    }
}
