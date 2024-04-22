using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class SerialManager : MonoBehaviour
{
    public string comPort = "COM1";
    public int baud = 9600;
    public Text outputText;

    public void Start()
    {
        Initialize();
    }

    private void Initialize(){
        Debug.Log("Init Serial Manager | Port: " + comPort + " | Baud: " + baud.ToString());
    }
    float counter = 0;
    public void Update()
    {
        counter += Time.deltaTime;
        if (counter > 5)
        {
            SerialPort mySerialPort = new SerialPort(comPort);
            mySerialPort.BaudRate = 9600;
            mySerialPort.Parity = Parity.None;
            mySerialPort.StopBits = StopBits.One;
            mySerialPort.DataBits = 8;
            mySerialPort.Handshake = Handshake.None;
            mySerialPort.Open();
            string value = mySerialPort.ReadLine();
            mySerialPort.Close();
            Debug.Log("Received Data: " + value);
            if (outputText != null)
            {
                outputText.text = value;
            }
            counter = 0;
        }
    }
}
