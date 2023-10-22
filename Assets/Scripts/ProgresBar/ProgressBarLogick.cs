using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class ProgressBarLogick : MonoBehaviour
{
    public float progresBarValueAmaount , max,  help;
    public static float curent;
    public GameObject upgradeMenu;
    
    void Update()
    {
            //Calculating anchorMax.x of ProgresBar fill
            help = (1/max)*curent;
            
            if (help>= 1)
            {
                max += 30;
                upgradeMenuLogick.playerLevel++;
                upgradeMenu.SetActive(true);
                curent = 0;
                progresBarValueAmaount = 0;
                Time.timeScale = 0;
            }
            //slowly adding to smooth ProgresBar
            if (progresBarValueAmaount < help)
            {
                progresBarValueAmaount += Time.deltaTime*0.7f;
            }
            GetComponent<RectTransform>().anchorMax = new Vector2(progresBarValueAmaount, 1);
    }
}
