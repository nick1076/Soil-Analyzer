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
    public Image loadingBar;
    public TextMeshProUGUI loading;

    public void UpdateGraphics(string data)
    {
        string[] info = data.Split('&');
        for (int i = 0; i < data.Length; i++)
        {
            switch (i)
            {
                case 1:
                    temp.text =  info[i] + "°";
                    break;
                case 2:
                    hum.text = info[i] + "%";
                    break;
                case 3:
                    float moi = Mathf.Round((1 - ((float)System.Int64.Parse(info[i]) / 655)) * 100);
                    if (moi < 0)
                    {
                        moi = 0;
                    }
                    else if (moi > 100)
                    {
                        moi = 100;
                    }

                    mois.text = moi.ToString() + "%";
                    break;
                case 4:
                    n.text = info[i] + "mg/kg";
                    break;
                case 5:
                    p.text = info[i] + "mg/kg";
                    break;
                case 6:
                    k.text = info[i] + "mg/kg";
                    break;
            }
        }
    }
}
