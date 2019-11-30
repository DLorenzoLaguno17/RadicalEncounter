using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wanderer : Behaviour
{
    public float WanderOffset = 1.5f;
    float WanderRadius = 4.0f;
    float WanderRate = 0.4f;
    float WanderOrientation = 0;

    MovementManager Movement;
    FollowPathMesh FPMesh;

    void Start()
    {
        Movement = GetComponent<MovementManager>();
        FPMesh = GetComponent<FollowPathMesh>();
    }

    void Update()
    {
        Steer();
    }

    public void Steer()
    {
        if (!FPMesh)
            FPMesh = GetComponent<FollowPathMesh>();

        if (!Movement)
            Movement = GetComponent<MovementManager>();

        ////WanderOrientation += RandomBinomial() * WanderRate;
        ////float targetOrientation = WanderOrientation + Movement.rotation;

        ////Vector3 targetPosition = transform.position + (OrientationToVector(Movement.rotation) * WanderOffset);
        ////targetPosition = targetPosition + (OrientationToVector(targetOrientation) * WanderRadius);
        FPMesh.Steer(GetRandomLocation());
    }

    float RandomBinomial()
    {
        return Random.value - Random.value;
    }

    public static Vector3 OrientationToVector(float orientation)
    {
        return new Vector3(Mathf.Cos(-orientation), 0, Mathf.Sin(-orientation));
    }

    Vector3 GetRandomLocation()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        // Pick the first indice of a random triangle in the nav mesh
        int t = Random.Range(0, navMeshData.indices.Length - 3);

        // Select a random point on it
        Vector3 point = Vector3.Lerp(navMeshData.vertices[navMeshData.indices[t]], navMeshData.vertices[navMeshData.indices[t + 1]], Random.value);
        Vector3.Lerp(point, navMeshData.vertices[navMeshData.indices[t + 2]], Random.value);

        return point;
    }

}
