using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using UnityEngine;
using TMPro;

public class upgradeMenuLogick : MonoBehaviour
{
    public static int  fierRateTimes, bulletWidthTimes,bulletMultiplierTimes, homingMissilesTimes;
    public static int playerLevel;
    public GameObject[] buttons;
    
    void OnEnable()
    {
        if (fierRateTimes <2)
        {
            Instantiate(buttons[0], gameObject.transform).GetComponentInChildren<TextMeshProUGUI>().text ="Fier Rate+";
        }
        if (bulletWidthTimes <2)
        {
            Instantiate(buttons[1], gameObject.transform).GetComponentInChildren<TextMeshProUGUI>().text ="Bullet Width+";
        }
        if (bulletMultiplierTimes <6)
        {
            Instantiate(buttons[2], gameObject.transform).GetComponentInChildren<TextMeshProUGUI>().text ="Bullet Multiplier+";
        }
        if (homingMissilesTimes <4)
        {
            Instantiate(buttons[3], gameObject.transform).GetComponentInChildren<TextMeshProUGUI>().text ="Homing Missiles+";
        }
    }
}
