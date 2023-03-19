using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(lockCursor());
    }


    private IEnumerator lockCursor()
    {
        while (true)
        {
            if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                Cursor.visible = !Cursor.visible;
                if (Cursor.lockState == CursorLockMode.Locked)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.Locked;
                }
            }
            yield return null;
        }
    }
}
