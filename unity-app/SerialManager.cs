using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;

public class SerialManager : MonoBehaviour
{
    public string comPort = "COM1";
    public string sampleData = "&73.40&57.00&659&1&0&0&";
    public int baud = 9600;
    public Text outputText;
    public GraphicsManager graphicMan;

    public void Start()
    {
        if (graphicMan != null)
        {
            graphicMan.loading.gameObject.SetActive(false);
        }
        if (comPort != "COM1")
        {
            Initialize();
        }
        else
        {
            Debug.Log("Init Serial Manager | TEST MODE");
        }
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
            if (comPort != "COM1")
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
                //UpdateGraphics(value);
            }
            else
            {
                string value = sampleData;
                Debug.Log("Using Sample Data: " + value);
                UpdateGraphics(value);
            }
            counter = 0;
        }
        else
        {
            if (graphicMan != null)
            {
                graphicMan.loadingBar.fillAmount = counter / 4;
                if ((int)(5-counter) < 1)
                {
                    graphicMan.loading.gameObject.SetActive(true);
                }
            }
        }
    }

    public void UpdateGraphics(string value)
    {
        if (outputText != null)
        {
            outputText.text = value;
        }
        if (graphicMan != null)
        {
            graphicMan.loading.gameObject.SetActive(false);
            graphicMan.UpdateGraphics(value);
        }
    }
}
