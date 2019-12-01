using UnityEngine;
using NodeCanvas.Framework;

public class AttackBuilding : ActionTask
{
    FollowPathMesh followPath;
    MilitaryBehaviour militar;
    GameObject closestBuilding;
    bool arrivedToBuilding = false;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
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

        if (!arrivedToBuilding)
            followPath.Steer(closestBuilding.transform.position);

        EndAction(true);
    }
}