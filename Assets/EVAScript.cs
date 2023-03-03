using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EVAScript : MonoBehaviour
{
    public TextMeshProUGUI myLabel;
    // Start is called before the first frame update
    void Start()
    {
        myLabel.GetComponent<TextMeshProUGUI>().text = "This is where EVA data is";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
