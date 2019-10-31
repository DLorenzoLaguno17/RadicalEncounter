using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{

    MovementManager Movement;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
    }

    void Update()
    {
        Steer(Movement.target.transform.position);
    }

    public void Steer(Vector3 targ)
    {
        if (!Movement)
            Movement = GetComponent<MovementManager>();

        Vector3 output = targ - transform.position;

        Vector3 OutputAux = GiveMaxAccel(output);
        Movement.AccelerateMovement(OutputAux);
    }

    public Vector3 GiveMaxAccel(Vector3 vec)
    {
        vec.Normalize();
        vec *= Movement.MaximumAcceleration;

        return vec;
    }
   
}
