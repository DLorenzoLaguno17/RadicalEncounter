using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float speed = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
            speed = 20.0f;

        if (Input.GetKey(KeyCode.D))
            speed = -20.0f;

        transform.Rotate(0, speed * Time.deltaTime, 0);

        speed = 0.0f;
    }
}
