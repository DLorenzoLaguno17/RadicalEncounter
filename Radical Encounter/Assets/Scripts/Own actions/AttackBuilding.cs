using UnityEngine;
using NodeCanvas.Framework;

public class AttackBuilding : ActionTask
{
    Arrive arrive;
    MilitaryBehaviour military;
    MovementManager movement;
    DestroyableBuildingsBehaviour closestBuilding;

    public float shotDelay = 0.5f;
    float nextShotTime;
    bool arrivedToBuilding = false;
    float distance = Mathf.Infinity;

    protected override string OnInit()
    {
        military = agent.gameObject.GetComponent<MilitaryBehaviour>();
        arrive = agent.gameObject.GetComponent<Arrive>();
        movement = agent.gameObject.GetComponent<MovementManager>();
        return null;
    }

    protected override void OnExecute()
    {
        // Distance to the closest destroyable building
        DestroyableBuildingsBehaviour[] buildings = GameObject.FindObjectsOfType<DestroyableBuildingsBehaviour>();

        foreach (DestroyableBuildingsBehaviour currentBuilding in buildings)
        {
            float newDistance = (currentBuilding.transform.position - agent.gameObject.transform.position).magnitude;
            if (newDistance < distance && currentBuilding.HP < 0)
            {
                distance = newDistance;
                closestBuilding = currentBuilding;
            }
        }
    }

    protected override void OnUpdate()
    {
        distance = (closestBuilding.transform.position - agent.gameObject.transform.position).magnitude;
        if (distance < 15)
            arrivedToBuilding = true;

        // Check if has arrived to the building
        if (arrivedToBuilding)
        {
            agent.gameObject.transform.LookAt(closestBuilding.transform.position);
            movement.SetMovementVelocity(Vector3.zero);

            if (Time.time >= nextShotTime)
            {
                nextShotTime = Time.time + shotDelay;
                military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
            }

            if (closestBuilding.HP == 0)
            {
                closestBuilding = null;
                EndAction(false);
            }

            Debug.Log(closestBuilding.tag);

        }
        else arrive.Steer(closestBuilding.transform.position, arrive.priority);        

        if (military.isHurt)
            EndAction(false);
    }
}