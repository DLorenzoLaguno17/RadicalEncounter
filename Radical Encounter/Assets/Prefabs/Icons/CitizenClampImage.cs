using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CitizenClampImage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image sleep;
    public Image flee;
    public Image repair;

    CitizenBehaviour citizen;

    private void Start()
    {
        citizen = gameObject.gameObject.GetComponentInParent<CitizenBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (citizen.goToSleep)
        {
            sleep.enabled = true;
            sleep.transform.position = namePos;

            flee.enabled = false;
            repair.enabled = false;
        }
        else if (citizen.militarSeen)
        {
            flee.enabled = true;
            flee.transform.position = namePos;

            sleep.enabled = false;
            repair.enabled = false;
        }
        else if (citizen.mustRepair)
        {
            repair.enabled = true;
            repair.transform.position = namePos;

            flee.enabled = false;
            sleep.enabled = false;
        }
        else
        {
            repair.enabled = false;
            flee.enabled = false;
            sleep.enabled = false;
        }
    }
}