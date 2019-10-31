using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour
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
        
    }

    public void Steer(Vector3 targ)
    {
        
    }
}
