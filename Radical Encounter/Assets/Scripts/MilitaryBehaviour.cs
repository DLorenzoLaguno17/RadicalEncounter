using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBehaviour : MonoBehaviour
{
    public int life;
    public int damage;

    public GameObject closestCitizen = null;
    public Transform shotSpawn = null;
    public GameObject shot;
    public int searchingRadius = 10;
    public int minDistance = 10;
    public bool citizenSeen = false;
    public bool citizenNear = false;
    public bool hasArrived = false;

    // Update is called once per frame
    void Update()
    {
        // Distance to the closest enemy
        float distance = Mathf.Infinity;
        GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizens");

        foreach (GameObject currentCitizen in citizens)
        {
            float newDistance = (currentCitizen.transform.position - transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                closestCitizen = currentCitizen;
            }
        }

        if (distance <= minDistance)
            citizenNear = true;
        else if (distance <= searchingRadius)
        {
            citizenNear = false;
            citizenSeen = true;
        }
        else
        {
            citizenNear = false;
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
            life -= 15;

            if (life <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}