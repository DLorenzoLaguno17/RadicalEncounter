using UnityEngine;
using NodeCanvas.Framework;

public class AttackBuilding : ActionTask
{
    FollowPathMesh followPath;
    MilitaryBehaviour military;
    GameObject closestBuilding;

    public float shotDelay = 0.5f;
    float nextShotTime;
    bool arrivedToBuilding = false;

    protected override string OnInit()
    {
        military = agent.gameObject.GetComponent<MilitaryBehaviour>();
        followPath = agent.gameObject.GetComponent<FollowPathMesh>();
        return null;
    }

    protected override void OnUpdate()
    {
        // Distance to the closest enemy
        float distance = Mathf.Infinity;
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Destroyable");

        foreach (GameObject currentBuilding in buildings)
        {
            float newDistance = (currentBuilding.transform.position - agent.gameObject.transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                closestBuilding = currentBuilding;
            }
        }

        /*if (!arrivedToBuilding)
        {
            followPath.Steer(closestBuilding.transform.position);
            Debug.Log(closestBuilding.tag);
        }*/

        if (Time.time >= nextShotTime)
        {
            nextShotTime = Time.time + shotDelay;
            military.ShootBullets(military.shot, military.shotSpawn.position, military.shotSpawn.rotation);
        }

        //EndAction(false);
    }
}