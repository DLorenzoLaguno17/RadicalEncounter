using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPathMesh : MonoBehaviour
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
        NavMesh.CalculatePath(transform.position, targ, NavMesh.AllAreas, path);
        Subtarget = path.corners[1];
        float distance = Subtarget.magnitude - transform.position.magnitude;

        if(distance < 0.5f && path.corners.Length > 2)
        { NavMesh.CalculatePath(transform.position, targ, NavMesh.AllAreas, path); }

        if(path.corners.Length > 2) { seek.Steer(Subtarget); }
        else { arrive.Steer(Subtarget); }
    }
}
