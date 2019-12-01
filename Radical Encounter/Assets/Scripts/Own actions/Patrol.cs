using UnityEngine;
using NodeCanvas.Framework;

public class Patrol : ActionTask
{
    public GameObject Point1;
    public GameObject Point2;
    public GameObject Point3;
    ActivistBehaviour activist;
    FollowPathMesh f_path;
    int step = 1;

    protected override string OnInit()
    {
        activist = agent.gameObject.GetComponent<ActivistBehaviour>();
        f_path = agent.gameObject.GetComponent<FollowPathMesh>();
        return null;
    }

    protected override void OnUpdate()
    {
        Vector3 distance = Vector3.zero;

        if (step == 1)
        {
            f_path.Steer(Point1.transform.position);
            distance = Point1.transform.position - agent.gameObject.transform.position;
        }
        else if (step == 2)
        {
            f_path.Steer(Point2.transform.position);
            distance = Point2.transform.position - agent.gameObject.transform.position;
        }
        else if (step == 3)
        {
            f_path.Steer(Point3.transform.position);
            distance = Point3.transform.position - agent.gameObject.transform.position;
        }

        if (distance.magnitude < 5)
        {
            if (step == 1) step = 2;
            else if (step == 2) step = 3;
            else if (step == 3) step = 1;
        }

        EndAction(false);
    }
}