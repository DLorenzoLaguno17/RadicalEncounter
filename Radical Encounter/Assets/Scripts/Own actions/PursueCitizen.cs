using UnityEngine;
using NodeCanvas.Framework;

public class PursueCitizen : ActionTask
{
    Pursue pursue;
    MilitaryBehaviour militar;
    int minDistance;
    int maxDistance;

    protected override string OnInit()
    {
        militar = agent.gameObject.GetComponent<MilitaryBehaviour>();
        pursue = agent.gameObject.GetComponent<Pursue>();
        minDistance = militar.minDistance;
        maxDistance = militar.searchingRadius;
        return null;
    }

    protected override void OnUpdate()
    {
        pursue.Steer(militar.closestCitizen.transform.position, militar.closestCitizen.GetComponent<MovementManager>().movement);

        // Check the distance between the militar and its objective 
        Vector3 distance = militar.closestCitizen.transform.position - agent.gameObject.transform.position;

        if (distance.magnitude < minDistance || distance.magnitude > maxDistance)
            EndAction(true);
        else EndAction(false);
    }
}