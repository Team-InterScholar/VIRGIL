using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcontrol : MonoBehaviour
{
    bool evaPressed = false;
    bool suitPressed = false;
    bool navPressed = false;
    bool roverPressed = false;

    // Update is called once per frame
    void Update() 
    {
        if (evaPressed == true)
            evaButton();
        if (suitPressed == true)
            suitButton();
        if (navPressed == true)
            navButton();
        if (roverPressed == true)
            roverButton();
    }

    public void evaButton()
    {
        //GameObject
    }

    public void suitButton()
    {
        //GameObject
    }

    public void navButton()
    {
        //GameObject
    }

    public void roverButton()
    {
        //GameObject
    }

    public void EVA()
    {
        bool evaPressed = true;
        bool suitPressed = false;
        bool navPressed = false;
        bool roverPressed = false;
    }

    public void SUIT()
    {
        bool evaPressed = false;
        bool suitPressed = true;
        bool navPressed = false;
        bool roverPressed = false;
    }

    public void NAV()
    {
        bool evaPressed = false;
        bool suitPressed = false;
        bool navPressed = true;
        bool roverPressed = false;
    }

    public void ROVER()
    {
        bool evaPressed = false;
        bool suitPressed = false;
        bool navPressed = false;
        bool roverPressed = true;
    }

    public void NA()
    {
        bool evaPressed = false;
        bool suitPressed = false;
        bool navPressed = false;
        bool roverPressed = false;
    }
}