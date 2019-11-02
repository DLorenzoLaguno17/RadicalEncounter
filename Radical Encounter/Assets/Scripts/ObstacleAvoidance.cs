using UnityEngine;
using System.Collections;

[System.Serializable]
public class RayCast : System.Object
{
    public float length = 5;
    public Vector3 direction = Vector3.forward;
    public Vector3 offset = Vector3.zero;
}

public class ObstacleAvoidance : Behaviour
{
    public LayerMask mask;
    public float avoidRadius = 5.0f;
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
        // Calculate a quaternion with rotation based on movement vector
        float alpha = Mathf.Atan2(Movement.movement.x, Movement.movement.z);
        Quaternion q = Quaternion.AngleAxis(Mathf.Rad2Deg * alpha, Vector3.up);

        // 3- Cast all rays. If one hit, get away from that surface using the hitpoint and normal info
        for (int i = 0; i < raycasts.Length; ++i)
        {
            RaycastHit hit;
            Vector3 origin = transform.position + q * raycasts[i].offset;

            if (Physics.Raycast(origin, q * raycasts[i].direction.normalized, out hit, raycasts[i].length, mask))
            {
                Vector3 newTarget;
                newTarget.x = hit.point.x;
                newTarget.z = hit.point.z;
                newTarget.y = transform.position.y;
                seek.Steer(newTarget + hit.normal * avoidRadius);
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
            for (int i = 0; i < raycasts.Length; i++)
            {
                Vector3 origin = transform.position + q * raycasts[i].offset;
                Gizmos.DrawLine(origin, origin + (q * raycasts[i].direction.normalized) * raycasts[i].length);
            }
        }
    }
}