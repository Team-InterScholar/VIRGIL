//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TSS;
//using UnityEditor.TerrainTools;
//using TSS.Msgs;
//using TMPro;
//using Codice.Client.Commands;

//public class ConnScriptOld : MonoBehaviour
//{

//    public GameObject missionTime;
//    public GameObject connectionStatusLabel;
//    public GameObject roomLabel;
//    public GameObject idLabel;
//    public TextMeshProUGUI testLabel;

//    public TextMeshProUGUI biometricsLabel;
//    public TextMeshProUGUI suitIntegrityLabel;
//    public TextMeshProUGUI alertsLabel;

//    public GameObject socketField;

//    TSSConnection tss;
//    string tssUri;

//    int msgCount = 0;

//    TMPro.TMP_Text gpsMsgBox;
//    TMPro.TMP_Text imuMsgBox;
//    TMPro.TMP_Text evaMsgBox;

//    TMPro.TMP_InputField inputField;

//    // Start is called before the first frame update
//    async void Start()
//    {
//        tss = new TSSConnection();
//        inputField = socketField.GetComponent<TMPro.TMP_InputField>();
//        //gpsMsgBox = GameObject.Find("GPS Msg Box").GetComponent<TMPro.TMP_Text>();
//        //imuMsgBox = GameObject.Find("IMU Msg Box").GetComponent<TMPro.TMP_Text>();
//        //evaMsgBox = GameObject.Find("EVA Msg Box").GetComponent<TMPro.TMP_Text>();

//    }

//    // Update is called once per frame
//    void Update()
//    {
//        // Updates the websocket once per frame
//        tss.Update();

//    }

//    public async void Connect()
//    {
//        tssUri = inputField.text;
//        print(tssUri);
//        //tssUri = "ws://localhost:3001";
//        print(tssUri);
//        var connecting = tss.ConnectToURI(tssUri);
//        Debug.Log("Connecting to " + tssUri);
//        // Create a function that takes asing TSSMsg parameter and returns void. For example:
//        // public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg) { ... }
//        // Then just subscribe to the OnTSSTelemetryMsg



//        //tss.OnTSSTelemetryMsg += (telemMsg) =>
//        //{
//        //    msgCount++;
//        //    //Debug.Log("Message #" + msgCount + "\nMessage:\n " + JsonUtility.ToJson(telemMsg, prettyPrint: true));

//        //    //if (telemMsg.GPS.Count > 0)
//        //    //{
//        //    //    gpsMsgBox.text = "GPS Msg: " + JsonUtility.ToJson(telemMsg.GPS[0], prettyPrint: true);
//        //    //    //print(telemMsg.EVA[0].timer);
//        //    //}
//        //    //else
//        //    //{
//        //    //    gpsMsgBox.text = "No GPS Msg received";
//        //    //}

//        //    //if (telemMsg.IMU.Count > 0)
//        //    //{
//        //    //    imuMsgBox.text = "IMU Msg: " + JsonUtility.ToJson(telemMsg.IMU[0], prettyPrint: true);
//        //    //}
//        //    //else
//        //    //{
//        //    //    imuMsgBox.text = "No IMU Msg received";
//        //    //}

//        //    //if (telemMsg.EVA.Count > 0)
//        //    //{
//        //    //    evaMsgBox.text = "EVA Msg: " + JsonUtility.ToJson(telemMsg.EVA[0], prettyPrint: true);
//        //    //}
//        //    //else
//        //    //{
//        //    //    evaMsgBox.text = "No EVA Msg received";
//        //    //}

//        //    //if (telemMsg.UIA.Count > 0)
//        //    //{
//        //    //    testLabel.text = "UIA Msg: " + JsonUtility.ToJson(telemMsg.UIA[0], prettyPrint: true);
//        //    //}
//        //    //else
//        //    //{
//        //    //    testLabel.text = "No UIA Msg received";
//        ////    //}
//        //};

//        tss.OnTSSTelemetryMsg += (telemMsg) => showTelemInfo(telemMsg);
//        //tss.OnTSSTelemetryMsg += (telemMsg) => updateUIA(telemMsg);
//        //tss.OnTSSTelemetryMsg += (telemMsg) => updateBiometrics(telemMsg);
//        //tss.OnTSSTelemetryMsg += (telemMsg) => updateSuitIntegrity(telemMsg);


//        // tss.OnOpen, OnError, and OnClose events just re-raise events from websockets.
//        // Similar to OnTSSTelemetryMsg, create functions with the appropriate return type and parameters, and subscribe to them
//        tss.OnOpen += () =>
//        {
//            connectionStatusLabel.GetComponent<TextMeshProUGUI>().text = "" +
//            "Connection: OPEN";

//            Debug.Log("Websocket connection opened");
//        };

//        //tss.OnError += (string e) =>
//        //{
//        //    connectionStatusLabel.GetComponent<TextMeshProUGUI>().text = "Connection: ERROR \n" + "Error Code: " + e;
//        //    Debug.Log("Websocket error occured: " + e);
//        //};

//        //tss.OnClose += (e) =>
//        //{
//        //    connectionStatusLabel.GetComponent<TextMeshProUGUI>().text = "Connection: CLOSED \n" +
//        //    "Exit Code:" + e;
//        //    Debug.Log("Websocket closed with code: " + e);
//        //};

//        await connecting;

//    }

//    // An example handler for the OnTSSMsgReceived event which just serializes to JSON and prints it all out
//    // Can be any function that returns void and has a single parameter of type TSS.Msgs.TSSMsg
//    public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg)
//    {
//        Debug.Log("Received the following telemetry data from the TSS:\n" + JsonUtility.ToJson(tssMsg, prettyPrint: true));
//    }

//    public void showTelemInfo(TSS.Msgs.TSSMsg tssMsg)
//    {
//        if (tssMsg.EVA.Count > 0)
//        {
//            missionTime.GetComponent<TMPro.TMP_Text>().text = "Mission Time: \n" + tssMsg.EVA[0].timer;
//            idLabel.GetComponent<TextMeshProUGUI>().text = "" +
//                "ID: " + tssMsg.EVA[0].id + "\n";
//            roomLabel.GetComponent<TextMeshProUGUI>().text = "" +
//                "Room: " + tssMsg.EVA[0].room + "\n";

//        }
//        else
//        {
//            missionTime.GetComponent<TextMeshProUGUI>().text = "No EVA msg received.";
//            idLabel.GetComponent<TextMeshProUGUI>().text = "No EVA msg received.";
//            roomLabel.GetComponent<TextMeshProUGUI>().text = "No EVA msg received.";
//        }
//    }

//    public void updateUIA(TSS.Msgs.TSSMsg telemMsg)
//    {
//        if (telemMsg.UIA.Count > 0)
//        {
//            //testLabel.text = "UIA Msg: " + JsonUtility.ToJson(telemMsg.UIA[0], prettyPrint: true);
//            Dictionary<string, bool>  UIABooleans = FindObjectOfType<UIADataHolderScript>().GetUIABooleans();

//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EMU1",telemMsg.UIA[0].emu1);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EMU2", telemMsg.UIA[0].emu2);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EV1 Supply", telemMsg.UIA[0].ev1_supply);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EV2 Supply", telemMsg.UIA[0].ev2_supply);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EMU1 O2", telemMsg.UIA[0].emu1_O2);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EEMU2 O2", telemMsg.UIA[0].emu2_O2);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("EV1 Waste", telemMsg.UIA[0].ev_waste);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("O2 Vent", telemMsg.UIA[0].O2_vent);
//            FindObjectOfType<UIADataHolderScript>().setUIABoolean("Depress Pump", telemMsg.UIA[0].depress_pump);



//            if(FindObjectOfType<UIAObjectScript>() == null)
//            {
//                // catch object not set to instance error
//            }
//            else
//            {
//                FindObjectOfType<UIAObjectScript>().setLastRefreshTime(telemMsg.EVA[0].timer);
//            }
//        }
//        else
//        {
//            testLabel.text = "No UIA Msg received";
//        }
//    }

//    public void updateBiometrics(TSS.Msgs.TSSMsg telemMsg)
//    {
//        if(telemMsg.EVA.Count > 0)
//        {
//            if (telemMsg.EVA[0].heart_bpm > 93 || telemMsg.EVA[0].heart_bpm < 85)
//            {
//                FindObjectOfType<AlertsDataHolderScript>().setUIABoolean("heartRate", false);
//            }
//            else
//            {
//                FindObjectOfType<AlertsDataHolderScript>().setUIABoolean("heartRate", true);
//            }
//            biometricsLabel.text = "Heart Rate: " + telemMsg.EVA[0].heart_bpm;
//        }
//        else
//        {
//            biometricsLabel.text = "No biometric data received";
//        }
//    }

//    public void updateSuitIntegrity(TSS.Msgs.TSSMsg telemMsg)
//    {
//        if (telemMsg.EVA.Count > 0)
//        {

//            suitIntegrityLabel.text = "Suit Pressure: " + telemMsg.EVA[0].p_suit + "\n"
//                                    + "Fan: " + telemMsg.EVA[0].v_fan + "\n"
//                                    + "O2 Pressure: " + telemMsg.EVA[0].p_o2 + "\n"
//                                    + "O2 Rate: " + telemMsg.EVA[0].rate_o2 + "\n"
//                                    + "Battery Capacity: " + telemMsg.EVA[0].cap_battery + "\n";
//        }
//        else
//        {
//            biometricsLabel.text = "No biometric data received";
//        }
//    }



//    //public void showConnectionStatus(string str)
//    //{
//    //    //connectionStatusLabel.GetComponent<TextMeshProUGUI>().text = str;
//    //    //print(str);
//    //}
//}