using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryBehaviour : MonoBehaviour
{
    public int life;
    public int damage;

    public GameObject closestCitizen;
    public bool citizenSeen = false;
    public bool citizenNear = false;
    public bool citizenFar = false;
    public bool hasArrived = false;

    // Update is called once per frame
    void Update()
    {
       // citizenSeen = true;
    }
}