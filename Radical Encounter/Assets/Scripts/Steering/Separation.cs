using UnityEngine;
using System.Collections;

public class Separation : Behaviour
{
    public LayerMask mask;
    public float search_radius = 5.0f;
    public AnimationCurve strength;

    MovementManager Movement;

    // Use this for initialization
    void Start()
    {
        Movement = GetComponent<MovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find other agents in the vicinity (use a layer for all agents)
        Collider[] colliders = Physics.OverlapSphere(transform.position, search_radius, mask);
        Vector3 avoidanceVelocity = Vector3.zero;

        foreach (Collider col in colliders)
        {
            // For each of them calculate a escape vector using the AnimationCurve
            // Sum up all vectors and trim down to maximum acceleration
            Vector3 distance = col.gameObject.transform.position - transform.position;
            avoidanceVelocity -= distance;
            Movement.AccelerateMovement(avoidanceVelocity.normalized * Movement.MaximumSpeed * strength.Evaluate(search_radius - distance.magnitude / search_radius), priority);
        }
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, search_radius);
    }
}