using UnityEngine;
using NodeCanvas.Framework;

public class AttackBuilding : ActionTask
{
    FollowPathMesh followPath;
    MilitaryBehaviour militar;
    GameObject building;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
        followPath = agent.gameObject.GetComponent<FollowPathMesh>();
        return null;
    }

    protected override void OnUpdate()
    {
        followPath.Steer(building.transform.position);
        EndAction(true);
    }
}