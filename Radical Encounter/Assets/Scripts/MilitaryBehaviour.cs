using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBehaviour : MonoBehaviour
{
    public int life;
    public int damage;
    float checkDelay = 1.0f;
    float nextCheckTime;

    public GameObject closestBuilding;
    LookWhereGoing look;
    public GameObject closestTarget = null;
    public Transform shotSpawn = null;
    public GameObject shot;
    public int searchingRadius = 10;
    public int minDistance = 10;
    public bool citizenSeen = false;
    public bool citizenNear = false;
    public bool hasArrived = false;
    public bool attackBuilding = false;
    public bool isHurt = false;
    float b_distance = Mathf.Infinity;

    private void Start()
    {
        look = GetComponent<LookWhereGoing>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to the closest destroyable building
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Destroyable");

        foreach (GameObject currentBuilding in buildings)
        {
            float newDistance = (currentBuilding.transform.position - transform.position).magnitude;
            if (newDistance < b_distance)
            {
                b_distance = newDistance;
                closestBuilding = currentBuilding;
            }

            if (b_distance <= 15)
                attackBuilding = true;
            else attackBuilding = false;
        }        

        // Distance to the closest citizen
        float distance = Mathf.Infinity;
        GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizens");

        foreach (GameObject currentCitizen in citizens)
        {
            float newDistance = (currentCitizen.transform.position - transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                closestTarget = currentCitizen;
            }
        }

        if (Time.time >= nextCheckTime)
        {
            nextCheckTime = Time.time + checkDelay;
            isHurt = false;
        }

        if (distance <= minDistance)
            citizenNear = true;
        else {
            look.enabled = true;
            citizenNear = false;

            if (distance <= searchingRadius)
                citizenSeen = true;
            else
                citizenSeen = false;
        }
    }

    public void ShootBullets(GameObject shot, Vector3 position, Quaternion rotation)
    {
        Instantiate(shot, position, rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActivistBullet")
        {
            Destroy(other.gameObject);
            isHurt = true;
            life -= 15;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}