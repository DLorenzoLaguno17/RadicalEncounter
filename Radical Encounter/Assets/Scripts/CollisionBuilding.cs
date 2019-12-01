using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBuilding : MonoBehaviour
{
    public GameObject ButtonRepair;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoldierBullet")
        {
            // Destroy the bullet
            Destroy(other.gameObject);

            if (transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP > 15)
            {
                transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP -= 15;
            }
            else if(transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP <= 15)
            {
                transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP = 0;
            }
        }
    }

    private void OnMouseDown()
    {
        ButtonRepair.GetComponentInParent<ButtonsBehaviour>().GoToRepair = gameObject;
    }
}
