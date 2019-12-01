using UnityEngine;
using NodeCanvas.Framework;

public class AttackBuilding : ActionTask
{
    MilitaryBehaviour military;
    MovementManager movement;

    public float shotDelay = 0.5f;
    float nextShotTime;

    protected override string OnInit()
    {
        military = agent.gameObject.GetComponent<MilitaryBehaviour>();
        movement = agent.gameObject.GetComponent<MovementManager>();
        return null;
    }

    protected override void OnUpdate()
    {
        if (military.closestBuilding != null)
        {
            float distance = (military.closestBuilding.transform.position - agent.gameObject.transform.position).magnitude;
            
            agent.gameObject.transform.LookAt(military.closestBuilding.transform.position);
            movement.SetMovementVelocity(Vector3.zero);

            if (Time.time >= nextShotTime)
            {
                nextShotTime = Time.time + shotDelay;
                military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
            }

            if (military.closestBuilding.GetComponentInParent<DestroyableBuildingsBehaviour>().HP == 0)
            {
                military.attackBuilding = false;
                EndAction(true);
            }

            if (military.isHurt)
            {
                military.attackBuilding = false;
                EndAction(true);
            }
        }
        else {
            military.attackBuilding = false;
            EndAction(true);
        }
    }
}