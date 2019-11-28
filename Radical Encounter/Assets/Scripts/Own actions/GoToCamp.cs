using UnityEngine;
using NodeCanvas.Framework;

public class GoToCamp : ActionTask
{
    MilitaryBehaviour militar;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
        return null;
    }

    protected override void OnUpdate()
    {
        EndAction(true);
    }
}