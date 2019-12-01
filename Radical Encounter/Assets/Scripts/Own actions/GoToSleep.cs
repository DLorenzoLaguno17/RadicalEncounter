using UnityEngine;
using NodeCanvas.Framework;

public class GoToSleep : ActionTask
{
    FollowPathMesh f_path;
    CitizenBehaviour citizen;

    protected override string OnInit()
    {
        citizen = agent.gameObject.GetComponent<CitizenBehaviour>();
        f_path = agent.gameObject.GetComponent<FollowPathMesh>();
        return null;
    }

    protected override void OnUpdate()
    {
        //f_path.Steer(militar.transform.position);
        EndAction(true);
    }
}