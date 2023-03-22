using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EVAButtonScript : MonoBehaviour
{
    public Button evaButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnButtonPressed()
    {
        evaButton.onClick.Invoke();
    }
}
