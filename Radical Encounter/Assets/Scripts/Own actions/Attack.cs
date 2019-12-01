﻿using UnityEngine;
using NodeCanvas.Framework;

public class Attack : ActionTask
{
    public float RotSpeed = 5.5f;
    public float shotDelay = 0.5f;
    float nextShotTime;
    MilitaryBehaviour military;
    MovementManager movement;
    LookWhereGoing look;

    protected override string OnInit()
    {
        /*if(agent.tag == "Military")
            behaviour = agent.gameObject.GetComponent<MilitaryBehaviour>();
        else if(agent.tag == "Activist")*/
        military = agent.gameObject.GetComponent<MilitaryBehaviour>();
        movement = agent.gameObject.GetComponent<MovementManager>();
        look = agent.gameObject.GetComponent<LookWhereGoing>();

        return null;
    }

    protected override void OnUpdate()
    {
        agent.gameObject.transform.LookAt(military.closestTarget.transform.position);
        look.enabled = false;
        movement.SetMovementVelocity(Vector3.zero);

        if (Time.time >= nextShotTime) {
            nextShotTime = Time.time + shotDelay;
            military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
        }

        if (military.citizenNear == false)
            EndAction(true);
        else EndAction(false);
    }
}