using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnNCycle : MonoBehaviour
{

    public float daylength = 2;
    public float nightlength = 2;
    float time = 2;
    float hour = 0;
    public Light sun;
    bool itsnight = false;

    void Start()
    {
        
    }

    void Update()
    {
        sun.transform.Rotate(Time.deltaTime / time, 0, 0);
        hour += Time.deltaTime / time;

        if(hour >= 360)
        {
            hour = 0;
        }

        if(hour > 180)
        {
            //Night time
            time = nightlength;
            sun.intensity -= Time.deltaTime;
            itsnight = true;
        }

        if(hour <= 180)
        {
            time = daylength;
            sun.intensity += Time.deltaTime;
            itsnight = false;
        }

        if(sun.intensity >= 1)
        {
            sun.intensity = 1.0f;
        }

        if(sun.intensity <= 0.2)
        {
            sun.intensity = 0.2f;
        }
    }
}
