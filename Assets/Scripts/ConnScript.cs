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
    public TMPro.TMP_InputField welcomeInputField;
    public TMPro.TMP_Text missionTimeInfo;
    public TMPro.TMP_Text IDInfo;
    public TMPro.TMP_Text roomInfo;
    public TMPro.TMP_Text connectionStatusInfo;

    string teamName;
    string username;
    string university;
    string userGuid;

    public GameObject suitDataHolder;

    public Material red;
    public Material green;
    public Material yellow;

    public GameObject statusLight;

    bool isConnectedAtWelcomeCard;


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

    public bool getIsTelemOn()
    {
        return isConnectedAtWelcomeCard;
    }
    public void setIsTelemOn()
    {
        isConnectedAtWelcomeCard = false;
    }

    public async void WelcomeConnect()
    {
        tssUri = welcomeInputField.text;
        teamName = "Team InterScholar";
        username = "InterScholar1";
        university = "CerritosCollegeCalStateFullertonCalStateLongBeachCollegeoftheDesert";
        userGuid = "fdbee7e5-9887-495e-aabb-f10d1386a7e9";
        var connecting = tss.ConnectToURI(tssUri, teamName, username, university, userGuid);
        Debug.Log("Connecting to " + tssUri);

        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            missionTimeInfo.text = telemMsg.simulationStates.timer;
            IDInfo.text = "" + telemMsg.simulationStates.room_id;
            roomInfo.text = "";
        };

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setBatteryData(telemMsg.simulationStates.battery_percentage, telemMsg.simulationStates.battery_output, telemMsg.simulationStates.battery_capacity, telemMsg.simulationStates.battery_time_left);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setH2OData(telemMsg.simulationStates.h2o_liquid_pressure, telemMsg.simulationStates.h2o_gas_pressure, telemMsg.simulationStates.water_capacity, telemMsg.simulationStates.h2o_time_left); // float string error
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setHeartRate(telemMsg.simulationStates.heart_rate);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setIntegrityData(telemMsg.simulationStates.fan_tachometer, telemMsg.simulationStates.temperature, telemMsg.simulationStates.suits_pressure, telemMsg.simulationStates.sub_pressure);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setO2Data(telemMsg.simulationStates.oxygen_primary_time, telemMsg.simulationStates.o2_pressure, telemMsg.simulationStates.o2_rate, telemMsg.simulationStates.oxygen_secondary_time, telemMsg.simulationStates.sop_pressure, telemMsg.simulationStates.sop_rate, telemMsg.simulationStates.o2_time_left);

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<UIADataHolderScript>().SetUIABooleans(telemMsg.simulationStates.timer, telemMsg.uiaMsg.emu1_pwr_switch, telemMsg.uiaMsg.ev1_supply_switch, telemMsg.uiaMsg.emu1_water_waste, telemMsg.uiaMsg.emu1_o2_supply_switch, telemMsg.uiaMsg.o2_vent_switch, telemMsg.uiaMsg.depress_pump_switch);
        statusLight.GetComponent<MeshRenderer>().material = yellow;

        tss.OnOpen += () =>
        {
            connectionStatusInfo.text = "OPEN";
            Debug.Log("Websocket connection opened");

            statusLight.GetComponent<MeshRenderer>().material = green;
            isConnectedAtWelcomeCard = true;



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
            statusLight.GetComponent<MeshRenderer>().material = red;
        };



    }

    public async void Continue()
    {

    }

    public async void Connect()
    {
        tssUri = welcomeInputField.text;
        teamName = "Team InterScholar";
        username = "InterScholar1";
        university = "CerritosCollegeCalStateFullertonCalStateLongBeachCollegeoftheDesert";
        userGuid = "fdbee7e5-9887-495e-aabb-f10d1386a7e9";
        var connecting = tss.ConnectToURI(tssUri, teamName, username, university, userGuid);
        Debug.Log("Connecting to " + tssUri);
        // Create a function that takes asing TSSMsg parameter and returns void. For example:
        // public static void PrintInfo(TSS.Msgs.TSSMsg tssMsg) { ... }
        // Then just subscribe to the OnTSSTelemetryMsg
        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {

            missionTimeInfo.text = telemMsg.simulationStates.timer;
            IDInfo.text = "" + telemMsg.simulationStates.room_id;
            roomInfo.text = "";

            print(telemMsg.simulationStates.suits_pressure);

        };


        /* UNCOMMENT WHEN 2.0.0*/
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setBatteryData(telemMsg.simulationStates.battery_percentage, telemMsg.simulationStates.battery_output, telemMsg.simulationStates.battery_capacity, telemMsg.simulationStates.battery_time_left);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setH2OData(telemMsg.simulationStates.h2o_liquid_pressure, telemMsg.simulationStates.h2o_gas_pressure, telemMsg.simulationStates.water_capacity, telemMsg.simulationStates.h2o_time_left); // float string error
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setHeartRate(telemMsg.simulationStates.heart_rate);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setIntegrityData(telemMsg.simulationStates.fan_tachometer, telemMsg.simulationStates.temperature, telemMsg.simulationStates.suits_pressure,telemMsg.simulationStates.sub_pressure);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setO2Data(telemMsg.simulationStates.oxygen_primary_time, telemMsg.simulationStates.o2_pressure, telemMsg.simulationStates.o2_rate, telemMsg.simulationStates.oxygen_secondary_time, telemMsg.simulationStates.sop_pressure, telemMsg.simulationStates.sop_rate, telemMsg.simulationStates.o2_time_left);

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<UIADataHolderScript>().SetUIABooleans(telemMsg.simulationStates.timer, telemMsg.uiaMsg.emu1_pwr_switch, telemMsg.uiaMsg.ev1_supply_switch, telemMsg.uiaMsg.emu1_water_waste, telemMsg.uiaMsg.emu1_o2_supply_switch, telemMsg.uiaMsg.o2_vent_switch, telemMsg.uiaMsg.depress_pump_switch);
        //public void SetUIABooleans(string telemLastUpdated,bool emu1Pwr, bool ev1Supl, bool ev1Watwste, bool emu1o2supl, bool o2vnt, bool dprspump)

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