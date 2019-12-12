using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivistBehaviour : MonoBehaviour
{
    public int life;
    public int minLife;
    public bool isGoingToDie = false;

    LookWhereGoing look;
    public GameObject closestMilitar;
    public Transform shotSpawn = null;
    public GameObject shot;
    public bool militarSeen = false;
    public int search_radius;

    private void Start()
    {
        GameObject.Find("Game Controller").GetComponent<Money>().Ally++;
        look = GetComponent<LookWhereGoing>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distance to the closest soldier
        float distance = Mathf.Infinity;
        GameObject[] military = GameObject.FindGameObjectsWithTag("Military");

        foreach (GameObject currentMilitar in military)
        {
            float newDistance = (currentMilitar.transform.position - transform.position).magnitude;
            if (newDistance < distance)
            {
                distance = newDistance;
                closestMilitar = currentMilitar;
            }
        }

        if (life <= minLife)
            isGoingToDie = true;
        else
        {
            isGoingToDie = false;
            look.enabled = true;
        }

        if (distance <= search_radius)
            militarSeen = true;
        else
        { 
            militarSeen = false;
            look.enabled = true;
        }
    }

    public void ShootBullets(GameObject shot, Vector3 position, Quaternion rotation)
    {
        Instantiate(shot, position, rotation);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "SoldierBullet")
        {
            Destroy(other.gameObject);
            life -= 15;

            if (life <= 0)
            {
                GameObject.Find("Game Controller").GetComponent<Money>().Ally--;
                Destroy(gameObject);
            }
        }
    }
}