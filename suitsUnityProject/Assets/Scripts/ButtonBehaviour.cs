using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    public GameObject card;

    public void OnButtonPress() 
    {
        if (card.activeInHierarchy == true)
            card.SetActive(false);
        else
            card.SetActive(true);

    }
}
