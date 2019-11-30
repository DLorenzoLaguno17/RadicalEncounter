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
    }
}