using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsBehaviour : MonoBehaviour
{
    public GameObject GoToRepair;

    // Activists spawn variables
    [Header(" -------- Activists spawn variables -------- ")]
    public GameObject[] activists;
    public GameObject activistSpawn;
    public int activistCount;    

    public void Recruit()
    {
       for (int i = 0; i < activistCount; ++i)
       {
           Vector3 spawnPosition = new Vector3(activistSpawn.transform.position.x, activistSpawn.transform.position.y, activistSpawn.transform.position.z);

           Quaternion spawnRotation = Quaternion.identity;
           Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);

       }
    }

    public void Repair()
    {
        if(GoToRepair != null)
        {
            GoToRepair.GetComponentInParent<DestroyableBuildingsBehaviour>().HP = 150;
        }
    }
}
