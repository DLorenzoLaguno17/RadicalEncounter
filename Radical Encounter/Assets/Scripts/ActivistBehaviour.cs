using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivistBehaviour : MonoBehaviour
{
    public int life;
    public int minLife;
    public int damage;
    public bool isGoingToDie = false;

    public GameObject closestMilitar;
    public bool militarSeen = false;
    public int search_radius;

    // Update is called once per frame
    void Update()
    {
        if (life < minLife)
            isGoingToDie = true;

        // Seek for militars near it
       /* GameObject[] agents = Physics.OverlapSphere(transform.position, search_radius, mask);

        if (agents.Length > 0) militarSeen = true;
        foreach (GameObject agent in agents)
        {
            Vector3 distance = agent.gameObject.transform.position - transform.position;

            if (newDistance.magnitude < distance.magnitude || firstTime)
                closestMilitar = agent;
        }*/
    }
}