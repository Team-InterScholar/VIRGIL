using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SpectrometerDataHolderScript : MonoBehaviour
{
    public Dictionary<int, string> spectrometerData;
    public TextMeshProUGUI specLabel;
    public GameObject specLabelGO;
    public bool isShowing;
    // Start is called before the first frame update
    void Start()
    {
        spectrometerData = new Dictionary<int, string>();
        isShowing = false;
    }

    public void OnPressed()
    {
        isShowing = !isShowing;
        specLabelGO.SetActive(isShowing);
        if (isShowing == true)
        {
            specLabel.GetComponent<TextMeshProUGUI>().text = "spectro data here";
        }
    }

    public void addRock()
    {
        
    }
}
