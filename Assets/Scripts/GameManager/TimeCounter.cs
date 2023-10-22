using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCounter : MonoBehaviour
{
    private Func<bool> timeAction;
    private float time;

    public bool timeHandler(float maxMin)
    {
        return timeUp(maxMin);
    }

    private bool timeUp(float max)
    {
        time += Time.deltaTime;
        if (time >= max)
        {
            time = 0;
            return true;
        }

        return false;
    }
}