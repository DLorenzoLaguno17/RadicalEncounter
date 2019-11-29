using UnityEngine;
using NodeCanvas.Framework;

public class GoToCamp : ActionTask
{
    MilitaryBehaviour militar;
    FollowPathMesh followPath;
    public GameObject target;
    public int minDistance;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
        followPath = agent.gameObject.GetComponent<FollowPathMesh>();
        return null;
    }

    protected override void OnUpdate()
    {
        followPath.Steer(target.transform.position);

        Vector3 distance = target.transform.position - agent.gameObject.transform.position;
        if(distance.magnitude < minDistance)
        {
            militar.hasArrived = true;
            EndAction(true);
        }
    }
}