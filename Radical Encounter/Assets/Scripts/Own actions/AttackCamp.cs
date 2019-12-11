using UnityEngine;
using NodeCanvas.Framework;

public class AttackCamp : ActionTask
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
        // Find the closes building of the camp
        float distance = Mathf.Infinity;
        GameObject[] campBuildings = GameObject.FindGameObjectsWithTag("Camp");

        foreach (GameObject building in campBuildings)
        {
            float newDistance = (building.transform.position - agent.transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                military.closestBuilding = building;
            }
        }

        // Shoots it
        if (military.isHurt == false && distance < Mathf.Infinity)
        {
            agent.gameObject.transform.LookAt(military.closestBuilding.transform.position);
            movement.SetMovementVelocity(Vector3.zero);

            if (Time.time >= nextShotTime)
            {
                nextShotTime = Time.time + shotDelay;
                military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
            }

            if (military.closestBuilding.GetComponent<CampBuildingBehaviour>().HP == 0)
                EndAction(true);
        }
        else EndAction(true);
    }
}
