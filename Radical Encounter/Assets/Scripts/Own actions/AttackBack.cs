using UnityEngine;
using NodeCanvas.Framework;

public class AttackBack : ActionTask
{
    public float shotDelay = 0.5f;
    float nextShotTime;
    bool activistNear = false;

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

    protected override void OnUpdate()
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

        if (distance <= military.searchingRadius)
            activistNear = true;
        else activistNear = false;

        if (military.closestTarget != null) {
            agent.gameObject.transform.LookAt(military.closestTarget.transform.position);
            look.enabled = false;
            movement.SetMovementVelocity(Vector3.zero);

            if (Time.time >= nextShotTime)
            {
                nextShotTime = Time.time + shotDelay;
                military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
            }

            if (activistNear == false)
            {
                military.isHurt = false;
                EndAction(false);
            }
            else EndAction(true);
        }
    }
}