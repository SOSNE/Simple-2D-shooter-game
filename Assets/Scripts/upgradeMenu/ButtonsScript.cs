using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    private  GameObject upgradeMenu;
    private Transform Panel;
    private static float fierRate = 0.15f, BulletWidth= 0.2f, homingTime = 1f;
    private static int bulletMultiplier= 3;
    void Start()
    {
        upgradeMenu = GameObject.Find("upgradeMenu");
        Panel = GameObject.Find("Panel").transform;
    }

    public void FierRate1()
    {
        BuletSpawning.fierRateStatic = fierRate;
        upgradeMenuLogick.fierRateTimes++;
        Time.timeScale = 1;
        fierRate -= 0.05f;
        upgradeMenu.SetActive(false);
        foreach (Transform child in Panel)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void bulletWidth1()
    {
        BuletScript.BulletWidthStatic = BulletWidth;
        upgradeMenuLogick.bulletWidthTimes++;
        Time.timeScale = 1;
        BulletWidth += 0.6f;
        upgradeMenu.SetActive(false);
        foreach (Transform child in Panel)
        {
            Destroy(child.gameObject);
        }
    }
    
    public void BulletMultiplier()
    {
        BuletSpawning.bulletMultiplierStatic = bulletMultiplier;
        upgradeMenuLogick.bulletMultiplierTimes++;
        Time.timeScale = 1;
        bulletMultiplier += 2;
        upgradeMenu.SetActive(false);
        foreach (Transform child in Panel)
        {
            Destroy(child.gameObject);
        }
    }

    public void HomingMissiles()
    {
        BuletScript.homingOn = true;
        BuletScript.homingTime = homingTime;
        upgradeMenuLogick.homingMissilesTimes++;
        Time.timeScale = 1;
        homingTime += 0.2f;
        upgradeMenu.SetActive(false);
        foreach (Transform child in Panel)
        {
            Destroy(child.gameObject);
        }
    }
}