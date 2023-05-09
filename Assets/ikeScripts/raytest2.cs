using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raytest2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            print("Hit " + hit.transform.gameObject);
            print("Distance " + hit.transform.position);
        }
    }
}
