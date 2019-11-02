using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;

public class FollowPath : MonoBehaviour
{
    public BGCcMath path;
    public BGCurve curve;
    MovementManager Movement;
    Seek seek;

    public float FollowDistance = 5.0f;
    public float increment = 0.1f;
    float ratio = 0.0f;
    float FullRatio = 1.0f;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
        seek = GetComponent<Seek>();
    }

    void Update()
    {
        if (curve != null)
        {
            Vector3 destination = path.CalcPositionByDistanceRatio(ratio);
            Vector3 distance = transform.position - destination;

            if (ratio <= FullRatio)
            {
                if (distance.magnitude < FollowDistance)
                {
                    if (Movement.movement.magnitude != 0) { ratio += Time.deltaTime * increment * Movement.movement.magnitude; }
                    else { ratio += increment * Time.deltaTime; }
                }
            }

            if (distance.magnitude < FollowDistance && ratio >= FullRatio) { ratio = 0; }
            else { seek.Steer(destination); }
        }
    }
}
