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
            Vector3 center = transform.position + q * raycasts[i].offset;
            center.y = 1.0f;

            if (Physics.Raycast(center, q * raycasts[i].direction.normalized, out hit, raycasts[i].length, mask))
            {
                Vector3 newTarget = new Vector3(hit.point.x, transform.position.y, hit.point.z);
                seek.Steer(newTarget + hit.normal * avoidRadius, priority);               
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
                Vector3 center = transform.position + q * raycasts[i].offset;
                Gizmos.DrawLine(center, center + (q * raycasts[i].direction.normalized) * raycasts[i].length);
            }
        }
    }
}