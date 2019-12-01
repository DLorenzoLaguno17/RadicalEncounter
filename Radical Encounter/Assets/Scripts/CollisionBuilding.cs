using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBuilding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoldierBullet")
        {
            if(transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP > 15)
            {
                transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP -= 15;
            }
            else if(transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP < 15)
            {
                transform.parent.GetComponent<DestroyableBuildingsBehaviour>().HP = 0;
            }
        }
    }
}
