using UnityEngine;
using NodeCanvas.Framework;

public class PursueCitizen : ActionTask
{
    Pursue pursue;
    MilitaryBehaviour militar;
    GameObject citizen;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
        pursue = agent.gameObject.GetComponent<Pursue>();
        return null;
    }

    protected override void OnUpdate()
    {
        pursue.Steer(citizen.transform.position, citizen.GetComponent<MovementManager>().movement);
        EndAction(true);
    }
}