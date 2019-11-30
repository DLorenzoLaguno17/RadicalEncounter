using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    public int life;
    public bool mustRepair = false;
    public bool goToSleep = false;

    public GameObject closestMilitar;
    public bool militarSeen = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Game Controller").GetComponent<DayAndNightCycle>().isNight)
            goToSleep = true;
    }
}