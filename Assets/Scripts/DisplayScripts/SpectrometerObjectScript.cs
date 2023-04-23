using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpectrometerObjectScript : MonoBehaviour
{
    public TextMeshProUGUI labelSpectro;
    public GameObject refreshButton;

    private Dictionary<int, string> spectrometerData;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnButtonPressed()
    {

        //spectrometerData = FindObjectOfType<SpectrometerDataHolderScript>().GetSpectroData();
        //labelSpectro.GetComponent<TextMeshProUGUI>().text = " TBD ";



    }
}
