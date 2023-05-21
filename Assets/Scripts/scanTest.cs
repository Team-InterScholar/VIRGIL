using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class scanTest : MonoBehaviour
{
    float si, ti, al, fe, mn, mg, ca, k, p;
    public TMPro.TMP_Text typeBasalt;

    // Start is called before the first frame update
    void Start()
    {
        //TSS/backend/src/server/sockets/events/mappings/spec_data.map.ts
        if (si == 40.58 && ti == 12.83 && al == 10.91 && fe == 13.18 && mn == 0.19 && mg == 6.7 && ca == 10.64 && k == -0.11 && p == 0.34)
        {
            typeBasalt.text = "Mare Basalt";
        }
        else if (si == 36.89 && ti == 2.44 && al == 9.6 && fe == 14.52 && mn == 0.24 && mg == 5.3 && ca == 8.22 && k == -0.13 && p == 0.29)
        {
            typeBasalt.text = "Vesicular Basalt";
        }
        else if (si == 41.62 && ti == 2.44 && al == 9.52 && fe == 18.12 && mn == 0.27 && mg == 11.1 && ca == 8.12 && k == -0.12 && p == 0.28)
        {
            typeBasalt.text = "Olivine Basalt";
        }
        else if (si == 46.72 && ti == 1.1 && al == 19.01 && fe == 7.21 && mn == 0.14 && mg == 7.83 && ca == 14.22 && k == 0.43 && p == 0.65)
        {
            typeBasalt.text = "Feldspathic Basalt";
        }
        else if (si == 46.53 && ti == 3.4 && al == 11.68 && fe == 16.56 && mn == 0.24 && mg == 6.98 && ca == 11.11 && k == -0.02 && p == 0.38)
        {
            typeBasalt.text = "Pigeonite Basalt";
        }
        else if (si == 42.45 && ti == 1.56 && al == 11.44 && fe == 17.91 && mn == 0.27 && mg == 10.45 && ca == 9.37 && k == -0.08 && p == 0.34)
        {
            typeBasalt.text = "Olivine Basalt";
        }
        else if (si == 42.56 && ti == 9.38 && al == 12.03 && fe == 11.27 && mn == 0.17 && mg == 9.7 && ca == 10.52 && k == 0.28 && p == 0.44)
        {
            typeBasalt.text = "Ilmenite Basalt";
        }
        else
        {
            typeBasalt.text = "Basalt Type Unknown";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
