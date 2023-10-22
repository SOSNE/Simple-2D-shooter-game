using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    
public class HealthBarFill : MonoBehaviour
{
    
    public float max, help;
    private float HelthBarValueAmaount = 1;
    public static float Helthvaluecurent = 3;
    void Update()
    {
        //Calculating HpBar Fill amount
        help = (1 * Helthvaluecurent)/max;
        
        //Max Fill
        if (help >1)
        {
            help = 1;
        }
        //Slowly adding and subtracting from fill to make it smooth
        if (help+0.002 < HelthBarValueAmaount)
        {
            HelthBarValueAmaount -= Time.deltaTime;
        }else if (help-0.002 > HelthBarValueAmaount)
        {
            HelthBarValueAmaount += Time.deltaTime;
        }
        GetComponent<RectTransform>().anchorMax = new Vector2(HelthBarValueAmaount, 1);

    }
}
