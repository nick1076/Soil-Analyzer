using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphicsManager : MonoBehaviour
{
    public TextMeshProUGUI temp;
    public TextMeshProUGUI hum;
    public TextMeshProUGUI mois;
    public TextMeshProUGUI n;
    public TextMeshProUGUI p;
    public TextMeshProUGUI k;
    public TextMeshProUGUI counter;
    public TextMeshProUGUI loading;

    public void UpdateGraphics(string data)
    {
        string[] info = data.Split('&');
        for (int i = 0; i < data.Length; i++)
        {
            switch (i)
            {
                case 1:
                    temp.text = "Temperature: " + info[i] + "°";
                    break;
                case 2:
                    hum.text = "Humidity: " + info[i] + "%";
                    break;
                case 3:
                    mois.text = "Moisture: " + info[i];
                    break;
                case 4:
                    n.text = "Nitrogen: " + info[i] + "mg/kg";
                    break;
                case 5:
                    p.text = "Potassium: " + info[i] + "mg/kg";
                    break;
                case 6:
                    k.text = "Phosphorus: " + info[i] + "mg/kg";
                    break;
            }
        }
    }
}
