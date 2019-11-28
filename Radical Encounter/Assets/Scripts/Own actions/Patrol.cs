using UnityEngine;
using NodeCanvas.Framework;

public class Patrol : ActionTask
{
    ActivistBehaviour activist;

    protected override string OnInit()
    {
        activist = agent.gameObject.GetComponent<ActivistBehaviour>();
        return null;
    }

    protected override void OnUpdate()
    {
        EndAction(true);
    }
}