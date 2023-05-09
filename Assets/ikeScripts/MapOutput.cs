using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Microsoft.MixedReality.Toolkit.UX;
using UnityEngine.XR.Interaction.Toolkit;

public class MapOutput : MonoBehaviour
{
    //public GameObject irlScale;
    public GameObject user;
    public TMPro.TMP_Text x;
    public TMPro.TMP_Text z;
    //public GameObject map;
    public GameObject marker;
    float userXPos;
    float userZPos;
    float userYPos;
    float userRotation;
    float markerX;
    float markerZ;
    float markerRotation;
    float userRotationY;
    public TMPro.TMP_Text distancedata;
    public TMPro.TMP_Text positiondata;
    public GameObject flag;

    public MRTKTMPInputField mrtkDisplayEnterLong;
    float distance;

    // Start is called before the first frame update
    private void Start()
    {
        // putting everything from Update() in here also works, just won't move marker after start
    }

    // Update is called once per frame
    // Could probably remove variable count by combining them into longer calculations, but left them to show what each one is with a name.
    void Update()
    {
        // In real life:
        //      1. User moves with VisionKit

        // In Unity:
        //      1. A quad (with map texture) sits a hundred meters above ground level.
        //      2. A second camera sits 50 meters above it, pointing downwards.
        //      3. A red cube sits on map

        // In ConnScript:
        //      1. Read user's long and lat
        //      2. Compute distance of latitude from real life origin
        //      3. Compute distance of longtitude from real life origin
        //      4. Use setters for MapOutput to save computed distances

        // In MapOutput
        //      1. Add distances to virtual origin
        //      2. Updates red cube's position

        //  Concerns:
        //      




        //float xMeter = irlScale.transform.localScale.x * 10; //101
        //float zMeter = irlScale.transform.localScale.z * 10; //94.3
        //float xDiff = 101 - 0; //101
        //float zDiff = 0 - 94.3f; //-94.3
        userXPos = user.transform.position.x; //75
        userZPos = user.transform.position.z; //-25
        userRotationY = user.transform.rotation.eulerAngles.y;

        user.transform.position = new Vector3(userXPos, 1.72f, userZPos);

        marker.transform.position = new Vector3(userXPos, 86.0f, userZPos);
        marker.transform.rotation = Quaternion.Euler(90.0f, userRotationY, 0.0f);

        //marker
        x.text = "" + userXPos;
        z.text = "" + userZPos;

        //print("X: " + userXPos + ", Z:" + userZPos);
        //print("Rotation: " + userRotationY);

        //float markerX = xDiff - userXPos; //101 - 75 = 26
        //float markerZ = zDiff - userZPos; //-94.3 - (-25) = -69.3
        //float ratioPointX = markerX / xDiff; //0.25742574257
        //float ratioPointZ = markerZ / zDiff; //0.73488865323
        //float xMapPos = map.transform.position.x; //275
        //float yMapPos = map.transform.position.y; //40
        //var rectTransform = GetComponent<RectTransform>();
        //float width = rectTransform.sizeDelta.x; //303
        //float height = rectTransform.sizeDelta.y; //283
        //float xRightBorder = xMapPos + (width / 2.0f); //275 + (303/2) = 426.5

        //double xLeftBorder = xMapPos - (width / 2.0); //275 - (303/2)
        //double yTopBorder = yMapPos + (height / 2.0); //40 + (283/2) = 181.5

        //float yBotBorder = yMapPos - (height / 2.0f); //40 - (283/2) = -101.5
        //float xPos = xRightBorder - (width * ratioPointX); //426.5 - (303x.25)
        //float yPos = yBotBorder + (height * ratioPointX); //-101.5 + (283x.75)
        //Vector3 newPos = new Vector3(xPos, yPos, 0);
        //marker.transform.position = newPos;
    }

    public void submitDistance()
    {

        // get foot distance 
        distance = float.Parse(mrtkDisplayEnterLong.text);
        float altitude = 1.72f;
        float x = altitude / distance;
        float angle = Mathf.Acos(x);
        float distanceActual = Mathf.Sin(angle) * distance;
        distancedata.text = "" + distanceActual;

        // calculate position of flag
        float radians = (userRotationY / 180.0f) * 3.14f;
        print("user rotation is " + userRotationY);
        float horizCompVector = distanceActual * Mathf.Sin(radians);
        print("horizontal component is " + horizCompVector + "Mathf.sin is " + Mathf.Sin(radians));
        float vertCompVector = distanceActual * Mathf.Cos(radians);
        print("vertical component is " + vertCompVector + "Mathf.cos is " + Mathf.Cos(radians) );
        
        float flagXPos = userXPos + horizCompVector;
        float flagZPos = userZPos + vertCompVector;

        positiondata.text = "horizont: " + horizCompVector + " verti:" + vertCompVector;

        Instantiate(flag, new Vector3(flagXPos, 0.0f, flagZPos), Quaternion.Euler(0, 0, 0));
    }

}