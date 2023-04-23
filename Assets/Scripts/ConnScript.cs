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

    public TMPro.TMP_InputField inputField;
    public TMPro.TMP_Text missionTimeInfo;
    public TMPro.TMP_Text IDInfo;
    public TMPro.TMP_Text roomInfo;
    public TMPro.TMP_Text connectionStatusInfo;

    public TMPro.TMP_Text emu1PowerSwitch;
    public TMPro.TMP_Text ev1SupplySwitch;
    public TMPro.TMP_Text o2Switch;
    public TMPro.TMP_Text ventSwitch;
    public TMPro.TMP_Text depressPumpSwitch;

    // Start is called before the first frame update
    async void Start()
    {
        tss = new TSSConnection();
        //inputField = GameObject.Find("InputField (TMP)").GetComponent<TMPro.TMP_InputField>();
        //missionTimeInfo = GameObject.Find("MissionTimeInfo").GetComponent<TMPro.TMP_Text>();
        //IDInfo = GameObject.Find("IDInfo").GetComponent<TMPro.TMP_Text>();
        //roomInfo = GameObject.Find("RoomInfo").GetComponent<TMPro.TMP_Text>();
        //connectionStatusInfo = GameObject.Find("ConnectionStatusInfo").GetComponent<TMPro.TMP_Text>();

        //emu1PowerSwitch = GameObject.Find("EMU1PowerSwitchInfo").GetComponent<TMPro.TMP_Text>();
        //ev1SupplySwitch = GameObject.Find("EV1SupplySwitchInfo").GetComponent<TMPro.TMP_Text>();
        //o2Switch = GameObject.Find("EMU1O2SwitchInfo").GetComponent<TMPro.TMP_Text>();
        //ventSwitch =  GameObject.Find("O2VentSwitchInfo").GetComponent<TMPro.TMP_Text>();
        //depressPumpSwitch = GameObject.Find("DepressPumpSwitchInfo").GetComponent<TMPro.TMP_Text>();



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

        tss.OnTSSTelemetryMsg += (telemMsg) => printUIA(telemMsg);
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


    void printUIA(TSS.Msgs.TSSMsg telemMsg)
    {
        if (telemMsg.UIA.Count > 0)
        {
            emu1PowerSwitch.text = "" + telemMsg.UIA[0].emu1;
            ev1SupplySwitch.text = "" + telemMsg.UIA[0].ev1_supply;
            o2Switch.text = "" + telemMsg.UIA[0].emu1_O2;
            ventSwitch.text = "" + telemMsg.UIA[0].O2_vent;
            depressPumpSwitch.text = "" + telemMsg.UIA[0].depress_pump;

            //TMPro.TMP_Text emu1PowerSwitch;
            //TMPro.TMP_Text ev1SupplySwitch;
            //TMPro.TMP_Text o2Switch;
            //TMPro.TMP_Text ventSwitch;
            //TMPro.TMP_Text depressPumpSwitch;

        }
        else
        {
            emu1PowerSwitch.text = "No UIA msg received";
            ev1SupplySwitch.text = "No UIA msg received";
            o2Switch.text = "No UIA msg received";
            ventSwitch.text = "No UIA msg received";
            depressPumpSwitch.text = "No UIA msg received";
        }
    }
    // An example handler for the OnTSSMsgReceived event which just serializes to JSON and prints it all out
    // Can be any function that returns void and has a single parameter of type TSS.Msgs.TSSMsg
    public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg)
    {
        Debug.Log("Received the following telemetry data from the TSS:\n" + JsonUtility.ToJson(tssMsg, prettyPrint: true));
    }
}