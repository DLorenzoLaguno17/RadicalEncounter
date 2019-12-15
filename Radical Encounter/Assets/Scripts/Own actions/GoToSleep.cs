using UnityEngine;
using NodeCanvas.Framework;

public class GoToSleep : ActionTask
{
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    public GameObject point5;

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
        Vector3 distance = Vector3.zero;

        int rand = Random.Range(1, 6);
        if (rand > 1.0f && rand <= 2.0f)
        {
            f_path.Steer(point1.transform.position);
            distance = point1.transform.position - agent.gameObject.transform.position;
        }
        else if (rand > 2.0f && rand <= 3.0f)
        {
            f_path.Steer(point2.transform.position);
            distance = point2.transform.position - agent.gameObject.transform.position;
        }
        else if (rand > 3.0f && rand <= 4.0f)
        {
            f_path.Steer(point3.transform.position);
            distance = point3.transform.position - agent.gameObject.transform.position;
        }
        else if (rand > 4.0f && rand <= 5.0f)
        {
            f_path.Steer(point4.transform.position);
            distance = point4.transform.position - agent.gameObject.transform.position;
        }
        else if (rand > 5.0f && rand <= 6.0f)
        {
            f_path.Steer(point5.transform.position);
            distance = point5.transform.position - agent.gameObject.transform.position;
        }

        if (distance.magnitude < 5)
        {
            citizen.DestroyThis();
            EndAction(true);
        }
    }
}