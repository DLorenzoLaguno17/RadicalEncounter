using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBehaviour : MonoBehaviour
{
    public int life;
    public int damage;

    public GameObject closestCitizen = null;
    public int searchingRadius;
    public bool citizenSeen = false;
    public bool citizenNear = false;
    public bool citizenFar = false;
    public bool hasArrived = false;

    // Update is called once per frame
    void Update()
    {
        // Distance to the closest enemy
        float distance = Mathf.Infinity;
        GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizens");

        foreach (GameObject currentCitizen in citizens)
        {
            float newDistance = (currentCitizen.transform.position - transform.position).sqrMagnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                closestCitizen = currentCitizen;
            }
        }

        if (distance <= searchingRadius)
            citizenSeen = true;
        else citizenSeen = false;
    }
}