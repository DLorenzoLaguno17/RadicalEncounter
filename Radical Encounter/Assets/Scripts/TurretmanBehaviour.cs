using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretmanBehaviour : MonoBehaviour
{
    public GameObject closestMilitar;
    public Transform shotSpawn = null;
    public GameObject shot;
    public bool militarSeen = false;

    public int search_radius;
    public float shotDelay = 0.5f;
    float nextShotTime;

    // Update is called once per frame
    void Update()
    {
        // Distance to the closest soldier
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

        if (distance <= search_radius)
            militarSeen = true;
        else militarSeen = false;

        if (militarSeen)
        {
            transform.LookAt(closestMilitar.transform.position);

            if (Time.time >= nextShotTime)
            {
               nextShotTime = Time.time + shotDelay;
               Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
    }
}
