using UnityEngine;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.UI;
using System;

public class BluetoothConnection : MonoBehaviour
{

	string arduinoName = "MyArduino";
	string arduinoServiceUuid = "asdf::asdf::asdf::1234";
    string[] characteristicUuids = {
         "{59c2f246-5199-11eb-ae93-0242ac130002}",      // CUUID 1
         "{617c753e-5199-11eb-ae93-0242ac130002}"       // CUUID 2
    };

    BLE ble;
    BLE.BLEScan scan;
    bool isScanning = false, isConnected = false;
    string deviceId = null;
    IDictionary<string, string> discoveredDevices = new Dictionary<string, string>();
    int devicesCount = 0;

    // BLE Threads 
    Thread scanningThread, connectionThread, readingThread;

    // GUI elements
    public TMPro.TMP_Text TextDiscoveredDevices, TextIsScanning, arduinoDeviceConnectionText, arduinoDeviceDataText;
    public GameObject ButtonEstablishConnection, ButtonStartScan;
    bool buttonEstablishConnectionBool;
    bool buttonStartScanBool;
    int remoteAngle, lastRemoteAngle;

    void Start()
	{
        ble = new BLE();
        buttonEstablishConnectionBool = false;
        //ButtonEstablishConnection.SetActive(buttonEstablishConnectionBool);
        buttonStartScanBool = false; 
        //ButtonStartScan.SetActive(buttonStartScanBool);
        arduinoDeviceConnectionText.text = arduinoName + " not found.";
        readingThread = new Thread(ReadBleData);
    }


    void Update()
    {
        if (isScanning)
        {
            if (buttonStartScanBool == true)
                buttonStartScanBool = false;
                //ButtonStartScan.SetActive(buttonStartScanBool);

            if (discoveredDevices.Count > devicesCount)
            {
                UpdateGuiText("scan");
                devicesCount = discoveredDevices.Count;
            }
        }
        else
        {
            /* Restart scan in same play session not supported yet.
            if (!ButtonStartScan.enabled)
                ButtonStartScan.enabled = true;
            */
            if (TextIsScanning.text != "Not scanning.")
            {
                TextIsScanning.color = Color.white;
                TextIsScanning.text = "Not scanning.";
            }
        }

        // The target device was found.
        if (deviceId != null && deviceId != "-1")
        {
            // Target device is connected and GUI knows.
            if (ble.isConnected && isConnected)
            {
                UpdateGuiText("writeData");
            }
            // Target device is connected, but GUI hasn't updated yet.
            else if (ble.isConnected && !isConnected)
            {
                UpdateGuiText("connected");
                isConnected = true;
                // Device was found, but not connected yet. 
            }
            else if (!buttonEstablishConnectionBool && !isConnected)
            {
                buttonEstablishConnectionBool = true;
                ButtonEstablishConnection.SetActive(buttonEstablishConnectionBool);
                arduinoDeviceConnectionText.text = "Found target device:\n" + arduinoName;
            }
        }
    }


    void UpdateGuiText(string action)
    {
        switch (action)
        {
            case "scan":
                //textdiscovereddevices.text = "";
                //foreach (keyvaluepair<string, string> entry in discovereddevices)
                //{
                //    textdiscovereddevices.text += "deviceid: " + entry.key + "\ndevicename: " + entry.value + "\n\n";
                //    debug.log("added device: " + entry.key);
                //}
                print("The arduino device was not found.\n");
                break;
            case "connected":
                buttonEstablishConnectionBool = false;
                ButtonEstablishConnection.SetActive(buttonEstablishConnectionBool);
                arduinoDeviceConnectionText.text = "Connected to target device:\n" + arduinoName;
                break;
            case "writeData":
                if (!readingThread.IsAlive)
                {
                    readingThread = new Thread(ReadBleData);
                    readingThread.Start();
                }
                if (remoteAngle != lastRemoteAngle)
                {
                    arduinoDeviceDataText.text = "Remote angle: " + remoteAngle;
                    lastRemoteAngle = remoteAngle;
                }
                break;
        }
    }

    private void ReadBleData(object obj)
    {
        byte[] packageReceived = BLE.ReadBytes();
        // Convert little Endian.
        // In this example we're interested about an angle
        // value on the first field of our package.
        remoteAngle = packageReceived[0];
        Debug.Log("Angle: " + remoteAngle);
        //Thread.Sleep(100);
    }


    public void StartScanHandler()
    {
        devicesCount = 0;
        isScanning = true;
        discoveredDevices.Clear();
        scanningThread = new Thread(ScanBleDevices);
        scanningThread.Start();
        TextIsScanning.color = new Color(244, 180, 26);
        TextIsScanning.text = "Scanning...";
        //TextDiscoveredDevices.text = "";
    }


    public void StartConHandler()
    {
        connectionThread = new Thread(ConnectBleDevice);
        connectionThread.Start();
    }

    void ConnectBleDevice()
    {
        if (deviceId != null)
        {
            try
            {
                ble.Connect(deviceId,
                arduinoServiceUuid,
                characteristicUuids);
            }
            catch (Exception e)
            {
                Debug.Log("Could not establish connection to device with ID " + deviceId + "\n" + e);
            }
        }
        if (ble.isConnected)
            Debug.Log("Connected to: " + arduinoName);
    }

    void ScanBleDevices()
    {
        scan = BLE.ScanDevices();
        Debug.Log("BLE.ScanDevices() started.");
        scan.Found = (_deviceId, deviceName) =>
        {

            Debug.Log("found device with name: " + deviceName);
            if(discoveredDevices.ContainsKey(_deviceId))
            {
                print(deviceName + " already found");
            }
            else
            {
                discoveredDevices.Add(_deviceId, deviceName);
            }


            if (deviceId == null && deviceName == arduinoName)
                deviceId = _deviceId;
        };

        scan.Finished = () =>
        {
            isScanning = false;
            Debug.Log("scan finished");
            if (deviceId == null)
                deviceId = "-1";
        };
        while (deviceId == null)
            Thread.Sleep(500);
        scan.Cancel();
        scanningThread = null;
        isScanning = false;

        if (deviceId == "-1")
        {
            Debug.Log("no device found!");
            return;
        }
    }

    //   public byte[] Read()
    //{
    //       BleApi.BLEData lInput;
    //       BleApi.PollData(out lInput, false);
    //       return lInput.buf;
    //   }

    //public void Write(string iText)
    //{
    //       byte[] payload = Encoding.ASCII.GetBytes(iText);
    //       BleApi.BLEData data = new BleApi.BLEData();
    //       data.buf = new byte[512];
    //       data.size = (short)payload.Length;
    //       data.deviceId = arduinoName;
    //       data.serviceUuid = arduinoUUID;
    //       //data.characteristicUuid = characteristicID;
    //       for (int i = 0; i < payload.Length; i++)
    //           data.buf[i] = payload[i];
    //       // no error code available in non-blocking mode
    //       BleApi.SendData(in data, false);
    //   }
}
