using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-------------------------------------------------------*/
/*  Script that lets a button close its parent panel
 *  by invoking the parent button
 *--------------------------------------------------------*/
public class ExitButtonScript : MonoBehaviour
{
    public Button parentButton;
    public void OnButtonPressed()
    {
        parentButton.onClick.Invoke();
    }
}
