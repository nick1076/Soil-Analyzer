using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class SerialManager : MonoBehaviour
{
    public string comPort = "COM1";
    public int baud = 9600;
    public UnityEngine.UI.Text outputText;
    bool coded;
    SerialPort curStream;
    public SerialManager(string com, int baud = 9600){
        coded=true;
        comPort=com;
        Initialize();
    }

    public void Start(){
        if (comPort != "COM1" && comPort != "" && !coded){
            Initialize();
        }
    }

    private void Initialize(){
        Debug.Log("Init Serial Manager | Port: " + comPort + " | Baud: " + baud.ToString());
        curStream = new SerialPort(comPort, baud);
        curStream.BaudRate = 9600;
        curStream.Parity = Parity.None;
        curStream.StopBits = StopBits.One;
        curStream.DataBits = 8;
        curStream.Handshake = Handshake.None;
        curStream.Open();
    }

    public void Update(){
        if (curStream != null){
            if (curStream.IsOpen){
                string value = curStream.ReadLine();
                Debug.Log("Received Data: " + value);
                if (outputText != null){
                    outputText.text = value;
                }
            }
        }
    }

    public void CloseStream(){
        if (curStream != null){
            curStream.Close();
            curStream = null;
        }
    }
}
