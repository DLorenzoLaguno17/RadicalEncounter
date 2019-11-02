using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : Behaviour
{
    MovementManager Movement;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
    }

    void Update()
    {
        Steer(Movement.target.transform.position);
    }

    public void Steer(Vector3 target)
    {
        if (!Movement)
            Movement = GetComponent<MovementManager>();

        Vector3 output = transform.position - target;

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
