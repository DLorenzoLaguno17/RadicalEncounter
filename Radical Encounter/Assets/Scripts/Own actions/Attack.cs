using UnityEngine;
using System;
using NodeCanvas.Framework;

public class Attack : ActionTask
{
    public float shotDelay = 0.5f;
    float nextShotTime;
    public GameObject shot;
    MilitaryBehaviour military;

    protected override string OnInit()
    {
        /*if(agent.tag == "Military")
            behaviour = agent.gameObject.GetComponent<MilitaryBehaviour>();
        else if(agent.tag == "Activist")*/
            military = agent.gameObject.GetComponent<MilitaryBehaviour>();

        return null;
    }

    protected override void OnUpdate()
    {
        if (Time.time >= nextShotTime) {
            nextShotTime = Time.time + shotDelay;
            military.ShootBullets(shot, military.shotSpawn.position, military.shotSpawn.rotation);
        }

        if(military.citizenNear == false)
            EndAction(true);
    }
}