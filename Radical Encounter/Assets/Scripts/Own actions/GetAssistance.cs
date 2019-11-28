using UnityEngine;
using NodeCanvas.Framework;

public class GetAssistance : ActionTask
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