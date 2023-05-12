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

    public GameObject suitDataHolder;


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


        /* UNCOMMENT WHEN 2.0.0*/
        //tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setBatteryData(telemMsg.EVA[0].batteryPercent, telemMsg.EVA[0].battery_out, telemMsg.EVA[0].cap_battery, telemMsg.EVA[0].t_battery);
        //tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setH2OData(telemMsg.EVA[0].p_h2o_l, telemMsg.EVA[0].p_h2o_g, telemMsg.EVA[0].t_water);
        //tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setHeartRate(telemMsg.EVA[0].heart_bpm);
        //tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setIntegrityData(telemMsg.EVA[0].v_fan,telemMsg.EVA[0].temp?, telemMsg.EVA[0].p_suit, telemMsg.EVA[0].p_sub);
        //tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setO2Data(telemMsg.EVA[0].o2)



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



    void printSpectr(TSS.Msgs.TSSMsg telemMsg)
    {
        //if (telemMsg.specMsg.count > 0)
        //{
        //    SiO2Info.text = "" + telemMsg.specMsg[0].SiO2;
        //    TiO2Info.text = "" + telemMsg.specMsg[0].TiO2;
        //    Al2O3.text = "" + telemMsg.specMsg[0].Al2O3;
        //    FeO.text = "" + telemMsg.specMsg[0].FeO;
        //    MnO.text = "" + telemMsg.specMsg[0].MnO;
        //    MgO.text = "" + telemMsg.specMsg[0].MgO;
        //    CaO.text = "" + telemMsg.specMsg[0].CaO;
        //    K2O.text = "" + telemMsg.specMsg[0].K2O;
        //    P2O3.text = "" + telemMsg.specMsg[0].P2O3;

        //    //public TMPro.TMP_Text SiO2Info;
        //    //public TMPro.TMP_Text TiO2Info;
        //    //public TMPro.TMP_Text Al2O3;
        //    //public TMPro.TMP_Text FeO;
        //    //public TMPro.TMP_Text MnO;
        //    //public TMPro.TMP_Text CaO;
        //    //public TMPro.TMP_Text K2O;
        //    //public TMPro.TMP_Text P2O3; "no spec msg received";
        //}
        //else
        //{
        //    SiO2Info.text = "no spec msg received";
        //    TiO2Info.text = "no spec msg received";
        //    Al2O3.text = "no spec msg received";
        //    MnO.text = "no spec msg received";
        //    MgO.text = "no spec msg received";
        //    CaO.text = "no spec msg received";
        //    K2O.text = "no spec msg received";
        //    P2O3.text = "no spec msg received";
        //}
    }

    // An example handler for the OnTSSMsgReceived event which just serializes to JSON and prints it all out
    // Can be any function that returns void and has a single parameter of type TSS.Msgs.TSSMsg
    public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg)
    {
        Debug.Log("Received the following telemetry data from the TSS:\n" + JsonUtility.ToJson(tssMsg, prettyPrint: true));
    }
}