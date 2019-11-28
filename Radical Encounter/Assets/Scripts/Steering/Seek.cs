using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : Behaviour
{
    MovementManager Movement;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
    }

    void Update()
    {
        Steer(Movement.target.transform.position, priority);
    }

    public void Steer(Vector3 targ, int priority)
    {
        if (!Movement)
            Movement = GetComponent<MovementManager>();

        Vector3 output = targ - transform.position;

        Vector3 OutputAux = GiveMaxAccel(output);
        Movement.AccelerateMovement(OutputAux, priority);
    }

    public Vector3 GiveMaxAccel(Vector3 vec)
    {
        vec.Normalize();
        vec *= Movement.MaximumAcceleration;

        return vec;
    }   
}
