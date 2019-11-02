using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereGoing : MonoBehaviour
{
    public float RotSpeed = 5.5f;
    MovementManager Movement;

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<MovementManager>();

    }

    // Update is called once per frame
    void Update()
    {
        steer();
    }

    public void steer()
    {
        Vector3 direction = Movement.movement;
        float step = RotSpeed * Time.deltaTime;

        Vector3 FinalOrientation = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(FinalOrientation);
    }

}
