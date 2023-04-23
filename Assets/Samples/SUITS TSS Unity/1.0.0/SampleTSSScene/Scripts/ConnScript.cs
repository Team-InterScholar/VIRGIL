using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TSS;
using TMPro;

public class ConnScript : MonoBehaviour
{
    TSSConnection tss;
    string tssUri;

    int msgCount = 0;

    TMPro.TMP_InputField inputField;
    TMPro.TMP_Text missionTimeInfo;
    TMPro.TMP_Text IDInfo;
    TMPro.TMP_Text roomInfo;
    TMPro.TMP_Text connectionStatusInfo;

    // Start is called before the first frame update
    async void Start()
    {
        tss = new TSSConnection();
        inputField = GameObject.Find("InputField (TMP)").GetComponent<TMPro.TMP_InputField>();
        missionTimeInfo = GameObject.Find("MissionTimeInfo").GetComponent<TMPro.TMP_Text>();
        IDInfo = GameObject.Find("IDInfo").GetComponent<TMPro.TMP_Text>();
        roomInfo = GameObject.Find("RoomInfo").GetComponent<TMPro.TMP_Text>();
        connectionStatusInfo = GameObject.Find("ConnectionStatusInfo").GetComponent<TMPro.TMP_Text>();


    }

    // Update is called once per frame
    void Update()
    {
        // Updates the websocket once per frame
        tss.Update();

    }

    public async void Connect()
    {
        tssUri = inputField.text;
        var connecting = tss.ConnectToURI(tssUri);
        Debug.Log("Connecting to " + tssUri);
        // Create a function that takes asing TSSMsg parameter and returns void. For example:
        // public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg) { ... }
        // Then just subscribe to the OnTSSTelemetryMsg
        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            if (telemMsg.EVA.Count > 0)
            {
                missionTimeInfo.text = telemMsg.EVA[0].timer;
                IDInfo.text = "" + telemMsg.EVA[0].id;
                roomInfo.text = "" + telemMsg.EVA[0].room;

            }
            else
            {
                missionTimeInfo.text = "No EVA Msg received";
                IDInfo.text = "No EVA Msg received";
                roomInfo.text = "No EVA Msg received";
            }
        };

        // tss.OnOpen, OnError, and OnClose events just re-raise events from websockets.
        // Similar to OnTSSTelemetryMsg, create functions with the appropriate return type and parameters, and subscribe to them
        tss.OnOpen += () =>
        {
            connectionStatusInfo.text = "OPEN";
            Debug.Log("Websocket connection opened");
        };

        tss.OnError += (string e) =>
        {
            connectionStatusInfo.text = "ERROR " + e;
            Debug.Log("Websocket error occured: " + e);
        };

        tss.OnClose += (e) =>
        {
            connectionStatusInfo.text = "CLOSED " + e;
            Debug.Log("Websocket closed with code: " + e);
        };

        await connecting;

    }

    // An example handler for the OnTSSMsgReceived event which just serializes to JSON and prints it all out
    // Can be any function that returns void and has a single parameter of type TSS.Msgs.TSSMsg
    public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg)
    {
        Debug.Log("Received the following telemetry data from the TSS:\n" + JsonUtility.ToJson(tssMsg, prettyPrint: true));
    }
}