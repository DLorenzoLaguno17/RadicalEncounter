using UnityEngine;
using System;
using NodeCanvas.Framework;

public class Attack : ActionTask
{
    public float RotSpeed = 5.5f;
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
        float step = RotSpeed * Time.deltaTime;

       // Vector3 FinalOrientation = Vector3.RotateTowards(agent.gameObject.transform.forward, military.closestCitizen.transform.position, step, 0.0f);
       // agent.gameObject.transform.rotation = Quaternion.LookRotation(FinalOrientation);

        if (Time.time >= nextShotTime) {
            nextShotTime = Time.time + shotDelay;
            military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
        }

        if (military.citizenNear == false)
            EndAction(true);
        else EndAction(false);
    }
}