using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{
    public GameObject target;
    public GameObject aim;
    public Slider arrow;

    public float MaxaimumSpeed = 5.0f;
    public float MaximumAcceleration = 0.1f;
    public float MaximumRotationSpeed = 10.0f; // in degrees / second
    public float MaximumRotationAcceleration = 0.1f; // in degrees

    public Vector3 movement = Vector3.zero;
    public float rotation = 0.0f; // degrees

    public void SetMovementVelocity(Vector3 velocity) { movement = velocity; }
    public void AccelerateMovement(Vector3 velocity) { movement += velocity; }
    public void SetRotationVelocity(float rotation_velocity) { rotation = rotation_velocity; }
    public void AccelerateRotation(float rotation_acceleration) { rotation += rotation_acceleration;}

    void Update()
    {
        // cap velocity
        if (movement.magnitude > MaxaimumSpeed)
        {
            movement.Normalize();
            movement *= MaxaimumSpeed;
        }

        // cap rotation
        Mathf.Clamp(rotation, -MaximumRotationSpeed, MaximumRotationSpeed);

        // rotate the arrow
        float angle = Mathf.Atan2(movement.x, movement.z);
        aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

        // strech it
        arrow.value = movement.magnitude * 4;

        // final rotate
        transform.rotation *= Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.up);

        // finally move
        movement.y = 0.0f;
        transform.position += movement * Time.deltaTime;
    }
}