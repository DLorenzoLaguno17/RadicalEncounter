using UnityEngine;
using System.Collections;

[System.Serializable]
public class RayCast : System.Object
{
    public float length = 5;
    public Vector3 direction = Vector3.zero;
}

public class ObstacleAvoid : Behaviour
{

    public LayerMask mask;
    public float avoid_distance = 5.0f;
    public RayCast[] raycasts;

    Seek seek;
    MovementManager Movement;

    // Use this for initialization
    void Start()
    {
        Movement = GetComponent<MovementManager>();
        seek = GetComponent<Seek>();
    }

    // Update is called once per frame
    void Update()
    {
        // TODO 2: Agents must avoid any collider in their way
        // 1- Create your own (serializable) class for rays and make a public array with it

        // 2- Calculate a quaternion with rotation based on movement vector
        float angle = Mathf.Atan2(Movement.movement.x, Movement.movement.z);
        Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

        RaycastHit hit;
        // 3- Cast all rays. If one hit, get away from that surface using the hitpoint and normal info
        for (int i = 0; i < raycasts.Length; ++i)
        {
            if (Physics.Raycast(transform.position, raycasts[i].direction, out hit, raycasts[i].length, mask))
            {
                //  hit.point;
                Vector3 newTarget = hit.point + hit.normal;
                seek.Steer(newTarget);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (Movement && this.isActiveAndEnabled)
        {
            Gizmos.color = Color.red;
            float angle = Mathf.Atan2(Movement.movement.x, Movement.movement.z);
            Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

            // TODO 2: Debug draw those rays (Look at Gizmos.DrawLine)
            Gizmos.DrawLine(transform.position, transform.TransformDirection(Vector3.forward));
            Debug.Log("Did Hit");
        }
    }
}
