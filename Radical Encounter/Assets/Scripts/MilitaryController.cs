using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitaryController : MonoBehaviour
{
    MovementManager Movement;
    FollowPathMesh followPathMesh;
    Pursue pursue;
    DayAndNightCycle DnN;
    public LayerMask mask;

    bool IsTargetInsideRange = false;
    public float Range = 10.0f;
    public Vector3 BasePosition;
    public Vector3 DisappearPos;


    // Start is called before the first frame update
    void Start()
    {
        BasePosition.x = 257.93f;
        BasePosition.y = 119.63f;
        BasePosition.z = -40.27f;

        DisappearPos.x = 266.16f;
        DisappearPos.y = 119.63f;
        DisappearPos.z = -111.5f;

        Movement = GetComponent<MovementManager>();
        followPathMesh = GetComponent<FollowPathMesh>();
        pursue = GetComponent<Pursue>();
        DnN = GetComponent<DayAndNightCycle>();
    }

    // Update is called once per frame
    void Update()
    {
        SearchTarget();

        //if(DnN.hour < 180)
        //{
        if (IsTargetInsideRange == false)
        {
            followPathMesh.Steer(BasePosition);
        }
        else if (IsTargetInsideRange == true)
        {
            pursue.Steer(Movement.target.transform.position, Movement.target.GetComponent<MovementManager>().movement);
        }
        //}
        //else
        //{
        //    if(1 < DisappearPos.magnitude - transform.position.magnitude)
        //        followPathMesh.Steer(DisappearPos);
        //    else
        //        Destroy(gameObject);
        //}

    }

    public void SearchTarget()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, Range, mask);
        foreach (Collider col in colliders)
        {
            if (col.gameObject.name == "Jojo Puentes" || col.gameObject.name == "Usollip" || col.gameObject.name == "Cram")
            {
                Movement.target = col.gameObject;
                IsTargetInsideRange = true;
            }
            else
                IsTargetInsideRange = false;
        }
    }

}