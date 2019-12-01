﻿using UnityEngine;
using NodeCanvas.Framework;

public class AttackBack : ActionTask
{
    public float shotDelay = 0.5f;
    float nextShotTime;
    MilitaryBehaviour military;
    MovementManager movement;
    LookWhereGoing look;

    protected override string OnInit()
    {
        military = agent.gameObject.GetComponent<MilitaryBehaviour>();
        movement = agent.gameObject.GetComponent<MovementManager>();
        look = agent.gameObject.GetComponent<LookWhereGoing>();
        return null;
    }

    protected override void OnExecute()
    {
        float distance = Mathf.Infinity;
        GameObject[] activists = GameObject.FindGameObjectsWithTag("Activists");

        foreach (GameObject currentActivist in activists)
        {
            float newDistance = (currentActivist.transform.position - agent.gameObject.transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                military.closestTarget = currentActivist;
            }
        }
    }

    protected override void OnUpdate()
    {
        agent.gameObject.transform.LookAt(military.closestTarget.transform.position);
        look.enabled = false;
        movement.SetMovementVelocity(Vector3.zero);

        if (Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + shotDelay;
            military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
        }

        if (military.citizenNear == false)
            EndAction(true);
        else EndAction(false);
    }
}