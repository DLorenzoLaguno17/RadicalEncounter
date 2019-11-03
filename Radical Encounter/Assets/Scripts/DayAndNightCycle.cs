﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayAndNightCycle : MonoBehaviour
{
    public float dayLength = 2.0f;
    public float nightLength = 2.0f;
    float time = 2.0f;
    float hour = 0.0f;
    public Light sun;
    bool itsNight = false;

    void Start()
    {
        
    }

    void Update()
    {
        sun.transform.Rotate(Time.deltaTime / time, 0, 0);
        hour += Time.deltaTime / time;

        if(hour >= 360) hour = 0;

        // Night time
        if (hour > 180)
        {
            time = nightLength;
            sun.intensity -= Time.deltaTime;
            itsNight = true;
        }

        // Day time
        if (hour <= 180)
        {
            time = dayLength;
            sun.intensity += Time.deltaTime;
            itsNight = false;
        }

        // Light intensity
        if(sun.intensity >= 1) sun.intensity = 1.0f;
        if(sun.intensity <= 0.01) sun.intensity = 0.01f;
    }
}