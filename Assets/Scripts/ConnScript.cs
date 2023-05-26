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

    float roverLat;
    float roverLon;
    float roverGoalLat;
    float roverGoalLon;
    string navigationStatus;

    float realBearing;
    float userLat;
    float userLon;
    float userAlt;

    // Start is called before the first frame update
    async void Start()
    {
        tss = new TSSConnection();




    }

    // Update is called once per frame
    void Update()
    {
        // Updates the websocket once per frame
        tss.Update();
        
    }
    public TSSConnection getTSSObject()
    {
        return tss;
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
        userGuid = "a75e207e-f70f-4e4f-a66a-9f47bb84ab29";
        var connecting = tss.ConnectToURI(tssUri, teamName, username, university, userGuid);
        Debug.Log("Connecting to " + tssUri);

        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            missionTimeInfo.text = telemMsg.simulationStates.timer;
            roomInfo.text = "" + telemMsg.simulationStates.room_id; ;


        };

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setBatteryData(telemMsg.simulationStates.battery_percentage, telemMsg.simulationStates.battery_output, telemMsg.simulationStates.battery_capacity, telemMsg.simulationStates.battery_time_left);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setH2OData(telemMsg.simulationStates.h2o_liquid_pressure, telemMsg.simulationStates.h2o_gas_pressure, telemMsg.simulationStates.water_capacity, telemMsg.simulationStates.h2o_time_left); // float string error
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setHeartRate(telemMsg.simulationStates.heart_rate);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setIntegrityData(telemMsg.simulationStates.fan_tachometer, telemMsg.simulationStates.temperature, telemMsg.simulationStates.suit_pressure, telemMsg.simulationStates.sub_pressure);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setO2Data(telemMsg.simulationStates.oxygen_primary_time, telemMsg.simulationStates.o2_pressure, telemMsg.simulationStates.o2_rate, telemMsg.simulationStates.oxygen_secondary_time, telemMsg.simulationStates.sop_pressure, telemMsg.simulationStates.sop_rate, telemMsg.simulationStates.o2_time_left);

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<UIADataHolderScript>().SetUIABooleans(telemMsg.simulationStates.timer, telemMsg.uiaMsg.emu1_pwr_switch, telemMsg.uiaMsg.ev1_supply_switch, telemMsg.uiaMsg.emu1_water_waste, telemMsg.uiaMsg.emu1_o2_supply_switch, telemMsg.uiaMsg.o2_vent_switch, telemMsg.uiaMsg.depress_pump_switch, telemMsg.uiaState.emu1_is_booted, telemMsg.uiaState.depress_pump_fault, telemMsg.uiaState.uia_supply_pressure, telemMsg.uiaState.water_level, telemMsg.uiaState.airlock_pressure);

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SpectrometerDataHolderScript>().setScanFloats(telemMsg.specMsg.SiO2, telemMsg.specMsg.TiO2, telemMsg.specMsg.Al2O3, telemMsg.specMsg.FeO, telemMsg.specMsg.MnO, telemMsg.specMsg.MgO,telemMsg.specMsg.CaO,telemMsg.specMsg.K2O, telemMsg.specMsg.P2O3);

        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            roverLat = telemMsg.roverMsg.lat;
            roverLon = telemMsg.roverMsg.lon;
            roverGoalLat = telemMsg.roverMsg.goal_lat;
            roverGoalLon = telemMsg.roverMsg.goal_lon;
            navigationStatus = telemMsg.roverMsg.navigation_status;

            userLat = telemMsg.gpsMsg.lat;
            userLon = telemMsg.gpsMsg.lon;
            realBearing = telemMsg.imuMsg.heading;
            userAlt = telemMsg.gpsMsg.alt;
            
        };

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

    public float getUserAlt()
    {
        return userAlt;
    }

    public float getUserLat()
    {
        return userLat;
    }

    public float getUserLon() { return userLon;}

    public async void Connect()
    {
        tssUri = welcomeInputField.text;
        teamName = "Team InterScholar";
        username = "InterScholar1";
        university = "CerritosCollegeCalStateFullertonCalStateLongBeachCollegeoftheDesert";
        userGuid = "a75e207e-f70f-4e4f-a66a-9f47bb84ab29";
        var connecting = tss.ConnectToURI(tssUri, teamName, username, university, userGuid);
        Debug.Log("Connecting to " + tssUri);

        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            missionTimeInfo.text = telemMsg.simulationStates.timer;
            roomInfo.text = "" + telemMsg.simulationStates.room_id; ;


        };

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setBatteryData(telemMsg.simulationStates.battery_percentage, telemMsg.simulationStates.battery_output, telemMsg.simulationStates.battery_capacity, telemMsg.simulationStates.battery_time_left);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setH2OData(telemMsg.simulationStates.h2o_liquid_pressure, telemMsg.simulationStates.h2o_gas_pressure, telemMsg.simulationStates.water_capacity, telemMsg.simulationStates.h2o_time_left); // float string error
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setHeartRate(telemMsg.simulationStates.heart_rate);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setIntegrityData(telemMsg.simulationStates.fan_tachometer, telemMsg.simulationStates.temperature, telemMsg.simulationStates.suit_pressure, telemMsg.simulationStates.sub_pressure);
        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SUITDataHolder>().setO2Data(telemMsg.simulationStates.oxygen_primary_time, telemMsg.simulationStates.o2_pressure, telemMsg.simulationStates.o2_rate, telemMsg.simulationStates.oxygen_secondary_time, telemMsg.simulationStates.sop_pressure, telemMsg.simulationStates.sop_rate, telemMsg.simulationStates.o2_time_left);

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<UIADataHolderScript>().SetUIABooleans(telemMsg.simulationStates.timer, telemMsg.uiaMsg.emu1_pwr_switch, telemMsg.uiaMsg.ev1_supply_switch, telemMsg.uiaMsg.emu1_water_waste, telemMsg.uiaMsg.emu1_o2_supply_switch, telemMsg.uiaMsg.o2_vent_switch, telemMsg.uiaMsg.depress_pump_switch, telemMsg.uiaState.emu1_is_booted, telemMsg.uiaState.depress_pump_fault, telemMsg.uiaState.uia_supply_pressure, telemMsg.uiaState.water_level, telemMsg.uiaState.airlock_pressure);

        tss.OnTSSTelemetryMsg += (telemMsg) => FindObjectOfType<SpectrometerDataHolderScript>().setScanFloats(telemMsg.specMsg.SiO2, telemMsg.specMsg.TiO2, telemMsg.specMsg.Al2O3, telemMsg.specMsg.FeO, telemMsg.specMsg.MnO, telemMsg.specMsg.MgO, telemMsg.specMsg.CaO, telemMsg.specMsg.K2O, telemMsg.specMsg.P2O3);

        tss.OnTSSTelemetryMsg += (telemMsg) =>
        {
            roverLat = telemMsg.roverMsg.lat;
            print("roverlat:" +  roverLat);
            roverLon = telemMsg.roverMsg.lon;
            roverGoalLat = telemMsg.roverMsg.goal_lat;
            roverGoalLon = telemMsg.roverMsg.goal_lon;
            navigationStatus = telemMsg.roverMsg.navigation_status;
        };
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

    public float getBearing()
    {
        return realBearing;
    }
    public float getRoverLat()
    {
        return roverLat;
    }
    public float getRoverLon()
    {
        return roverLon;
    }

    public float getRoverGoalLat()
    {
        return roverGoalLat;
    }

    public float getRoverGoalLon()
    {
        return roverGoalLon;
    }

    public string getNavigationStatus()
    {
        return navigationStatus;
    }


  
}