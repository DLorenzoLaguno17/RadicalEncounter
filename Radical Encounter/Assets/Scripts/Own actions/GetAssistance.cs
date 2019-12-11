using UnityEngine;
using NodeCanvas.Framework;

public class GetAssistance : ActionTask
{
    ActivistBehaviour activist;
    MovementManager movement;
    FollowPathMesh f_path;

    public GameObject CampPosition;
    public float healingDelay = 1.0f;
    float nextHealTime;

    protected override string OnInit()
    {
        activist = agent.gameObject.GetComponent<ActivistBehaviour>();
        f_path = agent.gameObject.GetComponent<FollowPathMesh>();
        movement = agent.gameObject.GetComponent<MovementManager>();

        return null;
    }

    protected override void OnUpdate()
    {
        Vector3 distance = Vector3.zero;
        distance = CampPosition.transform.position - agent.gameObject.transform.position;

        if (distance.magnitude < 5)
        {
            if (Time.time >= nextHealTime)
            {
                nextHealTime = Time.time + healingDelay;
                activist.life += 10;
                movement.SetMovementVelocity(Vector3.zero);
                if (activist.life >= 100) activist.life = 100;
            }

            if(activist.life == 100)
                EndAction(true);
        }
        else f_path.Steer(CampPosition.transform.position);
    }
}