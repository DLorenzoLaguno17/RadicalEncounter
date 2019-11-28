﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPathMesh : Behaviour
{
    MovementManager movement;
    private NavMeshPath path;
    Vector3 Subtarget;
    Arrive arrive;
    Seek seek;

    void Start()
    {
        seek = GetComponent<Seek>();
        arrive = GetComponent<Arrive>();
        movement = GetComponent<MovementManager>();
        path = new NavMeshPath();
    }

    void Update()
    {
        Steer(movement.target.transform.position);
    }

    public void Steer(Vector3 targ)
    {

        if(!seek)
            GetComponent<Seek>();
        if(!arrive)
            GetComponent<Arrive>();
        if (!movement)
            GetComponent<MovementManager>();
        if(path == null)
            path = new NavMeshPath();


            NavMesh.CalculatePath(transform.position, targ, NavMesh.AllAreas, path);
            if(path.corners.Length != 0)
                Subtarget = path.corners[1];

            float distance = Subtarget.magnitude - transform.position.magnitude;

            if (distance < 0.5f && path.corners.Length > 2)
            { NavMesh.CalculatePath(transform.position, targ, NavMesh.AllAreas, path); }

            if (path.corners.Length > 2) { seek.Steer(Subtarget, priority); }
            else { arrive.Steer(Subtarget, priority); }
    }
}