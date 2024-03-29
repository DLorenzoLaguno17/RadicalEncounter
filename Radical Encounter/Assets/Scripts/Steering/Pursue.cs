﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursue : Behaviour
{
    public float MaxPrediction = 2.0f;

    MovementManager Movement;
    Arrive arrive;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
        arrive = GetComponent<Arrive>();
    }

    void Update()
    {
        Steer(Movement.target.transform.position, Movement.target.GetComponent<MovementManager>().movement);
    }

    public void Steer (Vector3 targ, Vector3 TargVel)
    {
        if (!arrive)
            arrive = GetComponent<Arrive>();

        if (!Movement)
            Movement = GetComponent<MovementManager>();

        float prediction;

        Vector3 Direction = targ - transform.position;
        float Distance = Direction.magnitude;

        float Speed = Movement.movement.magnitude;

        if (Speed < Distance / MaxPrediction)
        {
            prediction = MaxPrediction;
        }
        else
        {
            prediction = Distance / Speed;
        }

        Vector3 RealTarget = targ;
        RealTarget += TargVel * prediction;

        arrive.Steer(RealTarget, priority);        
    }
}
