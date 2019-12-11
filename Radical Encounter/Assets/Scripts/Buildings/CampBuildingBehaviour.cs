using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampBuildingBehaviour : MonoBehaviour
{
    public int HP = 200;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoldierBullet")
        {
            // Destroy the bullet
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);

            HP -= 15;

            if (HP <= 0) {
                HP = 0;
                Destroy(gameObject);
            }
        }
    }
}
