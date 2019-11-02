﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Behaviour
{
    public float WanderOffset = 1.5f;
    float WanderRadius = 4.0f;
    float WanderRate = 0.4f;
    float WanderOrientation = 0;

    MovementManager Movement;
    Seek seek;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
        seek = GetComponent<Seek>();
    }

    void Update()
    {
        Steer();
    }

    public void Steer()
    {
        WanderOrientation += RandomBinomial() * WanderRate;
        float targetOrientation = WanderOrientation + Movement.rotation;

        Vector3 targetPosition = transform.position + (OrientationToVector(Movement.rotation) * WanderOffset);
        targetPosition = targetPosition + (OrientationToVector(targetOrientation) * WanderRadius);
        seek.Steer(targetPosition);

        Vector3 output = targetPosition - transform.position;

        output.Normalize();
        output *= Movement.MaximumAcceleration;
        Movement.AccelerateMovement(output, priority);
    }

    float RandomBinomial()
    {
        return Random.value - Random.value;
    }

    public static Vector3 OrientationToVector(float orientation)
    {
            return new Vector3(Mathf.Cos(-orientation), 0, Mathf.Sin(-orientation));
    }

}
