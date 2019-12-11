using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBuilding : MonoBehaviour
{
    public GameObject ButtonRepair;

    public AudioClip clip1;
    public AudioClip clip2;

    AudioSource source;
    uint bin = 0;

    private void Start()
    {
        source = gameObject.GetComponentInParent<AudioSource>();
    }

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

            if (bin % 2 == 0) source.clip = clip1;
            else source.clip = clip2;

            source.Play();
            bin++;
        }
    }

    private void OnMouseDown()
    {
        ButtonRepair.GetComponentInParent<ButtonsBehaviour>().GoToRepair = gameObject;
    }
}
