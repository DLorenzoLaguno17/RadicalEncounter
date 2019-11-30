using UnityEngine;
using NodeCanvas.Framework;

public class GoToCamp : ActionTask
{
    MilitaryBehaviour militar;
    MovementManager move;
    public GameObject target;
    public int minDistance;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
        move = agent.gameObject.GetComponent<MovementManager>();
        return null;
    }

    protected override void OnExecute()
    {
        move.target = target;
    }

    protected override void OnStop()
    {
        move.target = null;
    }

    protected override void OnUpdate()
    {
        Vector3 distance = target.transform.position - agent.gameObject.transform.position;
        if (distance.magnitude < minDistance)
        {
            militar.hasArrived = true;
            EndAction(true);
        }
    }
}