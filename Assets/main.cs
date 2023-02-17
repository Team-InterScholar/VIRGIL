using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    Vector3 pos0;
    // Vector3 dest = new Vector3(1.0f, 0.5f, 3.0f);
    // Start is called before the first frame update
    void Start()
    {
        pos0 = gameObject.transform.position;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = gameObject.transform.position;
        if (pos.x > 1.0f)
        {
            Debug.Log("MORE");
        }

        Debug.Log(pos);
    }
}
