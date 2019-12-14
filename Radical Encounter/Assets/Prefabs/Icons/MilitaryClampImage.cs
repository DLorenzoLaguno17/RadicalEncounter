using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MilitaryClampImage : MonoBehaviour
{
    // Start is called before the first frame update
    public Image search;
    public Image targeted;
    public Image attack;
    public Image building;

    MilitaryBehaviour military;

    private void Start()
    {
        military = gameObject.gameObject.GetComponentInParent<MilitaryBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);

        if (military.attackBuilding || military.hasArrived)
        {
            building.enabled = true;
            building.transform.position = namePos;

            search.enabled = false;
            targeted.enabled = false;
            attack.enabled = false;
        }
        else if (military.citizenSeen)
        {
            targeted.enabled = true;
            targeted.transform.position = namePos;

            search.enabled = false;            
            attack.enabled = false;
            building.enabled = false;
        }
        else if (military.citizenNear)
        {
            attack.enabled = true;
            attack.transform.position = namePos;

            search.enabled = false;
            targeted.enabled = false;            
            building.enabled = false;
        }
        else
        {
            search.enabled = true;
            search.transform.position = namePos;
            
            targeted.enabled = false;
            attack.enabled = false;
            building.enabled = false;
        }
    }
}