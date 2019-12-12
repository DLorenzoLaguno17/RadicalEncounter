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
    public int currency;
    public int enemies;

    private void Start()
    {
        look = GetComponent<LookWhereGoing>();
        currency = GameObject.Find("Game Controller").GetComponent<Money>().Currency;
        enemies = GameObject.Find("Game Controller").GetComponent<Money>().Enemy;

        enemies++;
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to the closest destroyable building
        float b_distance = Mathf.Infinity;
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Destroyable");

        foreach (GameObject currentBuilding in buildings)
        {
            float newDistance = (currentBuilding.transform.position - transform.position).magnitude;
            if (newDistance < b_distance && currentBuilding.GetComponentInParent<DestroyableBuildingsBehaviour>().HP > 0)
            {
                b_distance = newDistance;
                closestBuilding = currentBuilding;               
            }
        }

        if (b_distance <= 15 && hasArrived == false) 
            attackBuilding = true;
        else attackBuilding = false;

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

            gameObject.GetComponent<AudioSource>().Play();

            if (life <= 0)
            {
                currency = currency + 2;
                enemies--;
                Destroy(gameObject);
            }
        }
    }
}