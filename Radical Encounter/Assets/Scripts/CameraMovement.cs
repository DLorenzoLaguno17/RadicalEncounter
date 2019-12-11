using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform views;
    public float transitionSpeed;
    Transform currentView;
    bool FirstTimeCamera = true;

    void Start()
    {
        StartCoroutine(StopMovement());
    }

    void Update()
    {
        if(FirstTimeCamera)
        {
            currentView = views;
        }

    }


    void LateUpdate()
    {
        if(FirstTimeCamera)
        {
        //Lerp position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);

        Vector3 currentAngle = new Vector3(
         Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
         Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

        transform.eulerAngles = currentAngle;

        }

    }

    IEnumerator StopMovement()
    {


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        FirstTimeCamera = false;
    }
}
