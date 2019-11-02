using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementManager : MonoBehaviour
{
    public GameObject target;
    public GameObject aim;
    public Slider arrow;

    public float MaximumSpeed = 5.0f;
    public float MaximumAcceleration = 0.1f;
    public float MaximumRotationSpeed = 10.0f; // in degrees / second
    public float MaximumRotationAcceleration = 0.1f; // in degrees

    Vector3[] linear_velocities = new Vector3[Constants.prioritiesNumber];
    Vector3[] linear_accelerations = new Vector3[Constants.prioritiesNumber];
    float[] angular_velocities = new float[Constants.prioritiesNumber];
    float[] angular_accelerations = new float[Constants.prioritiesNumber];

    [Header("-------- Read Only --------")]
    public Vector3 movement = Vector3.zero;
    public float rotation = 0.0f; // degrees

    public void SetMovementVelocity(Vector3 velocity, int priority) { linear_velocities[priority] = velocity; }
    public void AccelerateMovement(Vector3 velocity, int priority) { linear_accelerations[priority] = velocity; }
    public void SetRotationVelocity(float rotation_velocity, int priority) { angular_velocities[priority] = rotation_velocity; }
    public void AccelerateRotation(float rotation_acceleration, int priority) { angular_accelerations[priority] = rotation_acceleration;}

    void Update()
    {
        // Priority checks
        for (int i = 0; i < linear_velocities.Length; ++i)
        {
            if (linear_velocities[i].magnitude > 0.0f)
                movement = linear_velocities[i];
        }

        for (int i = 0; i < linear_accelerations.Length; ++i)
        {
            if (linear_accelerations[i].magnitude > 0.0f)
                movement += linear_accelerations[i];
        }

        for (int i = 0; i < angular_velocities.Length; ++i)
        {
            if (angular_velocities[i] > 0.0f)
                rotation = angular_velocities[i];
        }

        for (int i = 0; i < angular_accelerations.Length; ++i)
        {
            if (angular_accelerations[i] > 0.0f)
                rotation += angular_accelerations[i];
        }

        // Cap velocity
        if (movement.magnitude > MaximumSpeed)
        {
            movement.Normalize();
            movement *= MaximumSpeed;
        }

        // Cap rotation
        Mathf.Clamp(rotation, -MaximumRotationSpeed, MaximumRotationSpeed);

        // Rotate the arrow
        float angle = Mathf.Atan2(movement.x, movement.z);
        aim.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * angle, Vector3.up);

        // Strech it
        arrow.value = movement.magnitude * 4;

        // Final rotate
        transform.rotation *= Quaternion.AngleAxis(rotation * Time.deltaTime, Vector3.up);

        // Finally move
        movement.y = 0.0f;
        transform.position += movement * Time.deltaTime;

        for (int i = 0; i < linear_velocities.Length; ++i)
            linear_velocities[i] = Vector3.zero;

        for (int i = 0; i < angular_velocities.Length; ++i)
            angular_velocities[i] = 0.0f;

        for (int i = 0; i < linear_accelerations.Length; ++i)
            linear_accelerations[i] = Vector3.zero;

        for (int i = 0; i < angular_accelerations.Length; ++i)
            angular_accelerations[i] = 0.0f;
    }
}