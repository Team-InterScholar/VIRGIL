using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpectrometerObjectScript : MonoBehaviour
{
    public GameObject panelSpectro;
    public TextMeshProUGUI labelSpectro;
    private bool isShowing;
    private Dictionary<int, string> spectrometerData;
    // Start is called before the first frame update
    void Start()
    {
        panelSpectro.SetActive(false);
        isShowing = false;
    }

    public void OnButtonPressed()
    {
        isShowing = !isShowing;
        panelSpectro.SetActive(isShowing);
        if (isShowing == true)
        {
            spectrometerData = FindObjectOfType<SpectrometerDataHolderScript>().GetSpectroData();
            labelSpectro.GetComponent<TextMeshProUGUI>().text = " test ";
        }


    }
}
