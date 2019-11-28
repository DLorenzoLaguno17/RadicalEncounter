using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryController : MonoBehaviour
{
    MovementManager Movement;
    FollowPathMesh followPathMesh;
    Arrive arrive;
    DayAndNightCycle DnN;
    public LayerMask mask;

    public float Range = 10.0f;
    public Vector3 DisappearPos;


    // Start is called before the first frame update
    void Start()
    {
        DisappearPos.x = 266.16f;
        DisappearPos.y = 119.63f;
        DisappearPos.z = -111.5f;

        Movement = GetComponent<MovementManager>();
        followPathMesh = GetComponent<FollowPathMesh>();
        arrive = GetComponent<Arrive>();
        DnN = GetComponent<DayAndNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizens");
        GameObject[] activists = GameObject.FindGameObjectsWithTag("Activists");


        Movement.target = GameObject.FindGameObjectWithTag("objective");
        foreach (GameObject cit in citizens)
        {
            float distance = Vector3.Distance(transform.position, cit.transform.position);

            if (distance <= Range)
            {
                followPathMesh.enabled = false;
                arrive.Steer(Movement.target.transform.position, 3);
            }

            else
            {
                followPathMesh.enabled = true;
            }


        }

    }
}