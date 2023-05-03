using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonColorChangeScript : MonoBehaviour
{
    public GameObject Object;
    MeshRenderer a_renderer;
    public Material red;
    public Material yellow;
    public Material green;

    // Start is called before the first frame update
    void Start()
    {
        a_renderer = Object.GetComponent<MeshRenderer>();
        a_renderer.material = red;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonPress()
    {
        a_renderer.material = green; 
    }
}
