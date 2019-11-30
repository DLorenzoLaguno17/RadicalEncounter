using UnityEngine;
using NodeCanvas.Framework;

public class GoToSleep : ActionTask
{
    Flee flee;
    CitizenBehaviour citizen;
    GameObject militar;

    protected override string OnInit()
    {
        citizen = agent.gameObject.GetComponent<CitizenBehaviour>();
        flee = agent.gameObject.GetComponent<Flee>();
        return null;
    }

    protected override void OnUpdate()
    {
        flee.Steer(militar.transform.position);
        EndAction(true);
    }
}