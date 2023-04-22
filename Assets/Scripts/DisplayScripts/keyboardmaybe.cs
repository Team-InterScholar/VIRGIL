using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardmaybe : MonoBehaviour
{
    [SerializeField]
    private TouchScreenKeyboard keyboard;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OpenSystemKeyboard()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (keyboard != null)
        {
            string keyboardText = keyboard.text;
            // Do stuff with keyboardText
        }
    }
}
