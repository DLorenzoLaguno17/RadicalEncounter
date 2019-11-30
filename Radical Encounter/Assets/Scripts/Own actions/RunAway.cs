using UnityEngine;
using NodeCanvas.Framework;

public class RunAway : ActionTask
{
    Evade evade;
    CitizenBehaviour citizen;

    protected override string OnInit()
    {
        citizen = agent.gameObject.GetComponent<CitizenBehaviour>();
        evade = agent.gameObject.GetComponent<Evade>();
        return null;
    }

    protected override void OnUpdate()
    {
        evade.Steer(citizen.closestMilitar.transform.position, citizen.closestMilitar.GetComponent<MovementManager>().movement);
       
        // Check the distance between the citizen and its enemy 
        Vector3 distance = citizen.closestMilitar.transform.position - agent.gameObject.transform.position;

        if (distance.magnitude > citizen.searchingRadius)
        {
            citizen.militarSeen = false;
            EndAction(false);
        }
    }
}