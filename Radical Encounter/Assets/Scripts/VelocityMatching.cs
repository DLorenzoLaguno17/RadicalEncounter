using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatching : Behaviour
{
    MovementManager Movement;

    public float timetotarget = 0.1f;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
    }

    void Update()
    {
        Steer();
    }

    public void Steer ()
    {
        Vector3 output;

        output = Movement.target.GetComponent<MovementManager>().movement - transform.GetComponent<MovementManager>().movement;
        output /= timetotarget;

        if(output.magnitude > Movement.MaximumAcceleration)
        {
            output.Normalize();
            output *= Movement.MaximumAcceleration;
        }

        Movement.AccelerateMovement(output, priority);

    }
}
