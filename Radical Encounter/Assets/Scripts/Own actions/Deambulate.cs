using UnityEngine;
using NodeCanvas.Framework;

public class Deambulate : ActionTask
{
    Wanderer wander;
    CitizenBehaviour citizen;
    GameObject militar;

    protected override string OnInit()
    {
        citizen = agent.gameObject.GetComponent<CitizenBehaviour>();
        wander = agent.gameObject.GetComponent<Wanderer>();
        return null;
    }

    protected override void OnUpdate()
    {
        wander.Steer();
        EndAction(false);
    }
}