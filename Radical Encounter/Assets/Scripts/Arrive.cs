using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : MonoBehaviour
{

    //float RadiusToTarget;
    public float SlowRadius = 5.0f;
    public float TimeToTarget = 0.1f;

    MovementManager Movement;

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<MovementManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Steer(Movement.target.transform.position);
    }

    public void Steer(Vector3 targ)
    {
        if (!Movement)
            Movement = GetComponent<MovementManager>();

        float TargetSpeed;
        Vector3 direction = targ - transform.position;
        float distance = direction.magnitude;

        if(distance > SlowRadius)
        {
            TargetSpeed = Movement.MaxaimumSpeed;
        }
        else
        {
            TargetSpeed = Movement.MaxaimumSpeed * distance / SlowRadius;
        }

        Vector3 TargetVelocity = direction;
        TargetVelocity.Normalize();
        TargetVelocity *= TargetSpeed;

        Vector3 output = TargetVelocity - Movement.movement;
        output /= TimeToTarget;

        if (output.magnitude > Movement.MaximumAcceleration)
        {
            output.Normalize();
            output *= Movement.MaximumAcceleration;
        }

        Movement.AccelerateMovement(output);
    }
}
