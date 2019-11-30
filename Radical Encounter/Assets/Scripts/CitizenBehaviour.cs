using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    public int life;
    public bool mustRepair = false;
    public bool goToSleep = false;

    public GameObject closestMilitar;
    public int searchingRadius = 10;
    public bool militarSeen = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Game Controller").GetComponent<DayAndNightCycle>().isNight)
            goToSleep = true;

        float distance = Mathf.Infinity;
        GameObject[] military = GameObject.FindGameObjectsWithTag("Military");

        foreach (GameObject currentMilitar in military)
        {
            float newDistance = (currentMilitar.transform.position - transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                closestMilitar = currentMilitar;
            }
        }

        if (distance <= searchingRadius)
            militarSeen = true;
        else militarSeen = false;
    }
}