using UnityEngine;
using NodeCanvas.Framework;

public class RepairBuilding : ActionTask
{
    CitizenBehaviour citizen;
    FollowPathMesh f_path;
    MovementManager movement;
    GameObject building;

    public AudioClip audio;
    public float repairingDelay = 1.0f;
    float nextRepairTime;

    protected override string OnInit()
    {
        citizen = agent.gameObject.GetComponent<CitizenBehaviour>();
        f_path = agent.gameObject.GetComponent<FollowPathMesh>();
        movement = agent.GetComponent<MovementManager>();
        building = citizen.buildingToRepair.GetComponent<DestroyableBuildingsBehaviour>().repairPoint;

        agent.gameObject.GetComponent<AudioSource>().clip = audio;
        agent.gameObject.GetComponent<AudioSource>().Play();

        return null;
    }

    protected override void OnUpdate()
    {
        Vector3 distance = Vector3.zero;
        distance = building.transform.position - agent.gameObject.transform.position;

        if (distance.magnitude < 5)
        {
            if (Time.time >= nextRepairTime)
            {
                nextRepairTime = Time.time + repairingDelay;
                citizen.buildingToRepair.GetComponent<DestroyableBuildingsBehaviour>().HP += 15;
                movement.SetMovementVelocity(Vector3.zero);

                if (citizen.buildingToRepair.GetComponent<DestroyableBuildingsBehaviour>().HP >= 150)
                {
                    citizen.buildingToRepair.GetComponent<DestroyableBuildingsBehaviour>().HP = 150;
                    citizen.mustRepair = false;
                    EndAction(true);
                }
            }
        }
        else f_path.Steer(building.transform.position);
    }
}