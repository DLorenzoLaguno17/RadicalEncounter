using UnityEngine;
using System;
using NodeCanvas.Framework;

public class Attack : ActionTask
{
    public float shotDelay = 0.5f;
    float nextShotTime;
    MilitaryBehaviour military;
    MovementManager movement;

    protected override string OnInit()
    {
        /*if(agent.tag == "Military")
            behaviour = agent.gameObject.GetComponent<MilitaryBehaviour>();
        else if(agent.tag == "Activist")*/
        military = agent.gameObject.GetComponent<MilitaryBehaviour>();
        movement = agent.gameObject.GetComponent<MovementManager>();

        return null;
    }

    protected override void OnUpdate()
    {
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