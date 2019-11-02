using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : MonoBehaviour
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
        Steer(Movement.target.transform.position);
    }

    public void Steer(Vector3 targ)
    {
        Vector3 Orientation = targ - transform.position;
        float step = RotSpeed * Time.deltaTime;

        Vector3 FinalOrientation = Vector3.RotateTowards(transform.forward, Orientation, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(FinalOrientation);
    }
}
