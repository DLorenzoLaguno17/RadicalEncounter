using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivistClampImage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healing;
    public Image attack;
    public Image patrol;

    ActivistBehaviour activist;

    private void Start()
    {
        activist = gameObject.gameObject.GetComponentInParent<ActivistBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (activist.isGoingToDie)
        {
            healing.enabled = true;
            healing.transform.position = namePos;

            attack.enabled = false;
            patrol.enabled = false;
        }
        else if (activist.militarSeen)
        {
            attack.enabled = true;
            attack.transform.position = namePos;

            healing.enabled = false;
            patrol.enabled = false;
        }
        else
        {
            patrol.enabled = true;
            patrol.transform.position = namePos;
                
            attack.enabled = false;
            healing.enabled = false;
        }
    }
}