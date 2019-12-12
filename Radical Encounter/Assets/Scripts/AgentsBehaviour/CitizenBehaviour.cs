using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenBehaviour : MonoBehaviour
{
    public int life;
    public bool mustRepair = false;
    public bool goToSleep = false;
    
    public GameObject closestMilitar;
    public GameObject buildingToRepair;
    public int searchingRadius = 10;
    public bool militarSeen = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Game Controller").GetComponent<DayAndNightCycle>().isNight)
            goToSleep = true;
        else goToSleep = false;

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

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoldierBullet")
        {
            Destroy(other.gameObject);
            life -= 15;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void DestroyThis() { Destroy(gameObject); }
}