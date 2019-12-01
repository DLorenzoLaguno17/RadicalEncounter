using UnityEngine;
using NodeCanvas.Framework;

public class AttackSoldier : ActionTask
{
    public float RotSpeed = 5.5f;
    public float shotDelay = 0.5f;
    float nextShotTime;
    ActivistBehaviour activist;
    MovementManager movement;
    LookWhereGoing look;

    protected override string OnInit()
    {
        activist = agent.gameObject.GetComponent<ActivistBehaviour>();
        movement = agent.gameObject.GetComponent<MovementManager>();
        look = agent.gameObject.GetComponent<LookWhereGoing>();

        return null;
    }

    protected override void OnUpdate()
    {
        agent.gameObject.transform.LookAt(activist.closestMilitar.transform.position);
        look.enabled = false;
        movement.SetMovementVelocity(Vector3.zero);

        if (Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + shotDelay;
            activist.ShootBullets(activist.shot, activist.shotSpawn.position, activist.shotSpawn.rotation);
        }

        if (activist.militarSeen == false)
            EndAction(true);
        else EndAction(false);
    }
}