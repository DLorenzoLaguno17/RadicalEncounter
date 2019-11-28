using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Military spawn variables
    [Header(" -------- Military spawn variables -------- ")]
    public GameObject[] military;
    public GameObject militarSpawn1;
    public GameObject militarSpawn2;
    public int militarCount;

    // Activists spawn variables
    [Header(" -------- Activists spawn variables -------- ")]
    public GameObject[] activists;
    public GameObject activistSpawn;
    public int activistCount;

    // Citizens spawn variables
    [Header(" -------- Citizens spawn variables -------- ")]
    public GameObject[] citizens;
    public GameObject citizenSpawn1;
    public GameObject citizenSpawn2;
    public GameObject citizenSpawn3;
    public GameObject citizenSpawn4;
    public GameObject citizenSpawn5;
    public int citizenCount;

    // Wait times
    [Header(" -------------- Spawn times -------------- ")]
    public float startWait;
    public float spawnWait;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnActivists());
        StartCoroutine(SpawnCitizens());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < militarCount; ++i) {

            Vector3 spawnPosition;
            if (Random.Range(0, 2) < 1.0f)
                 spawnPosition = new Vector3(Random.Range(militarSpawn1.transform.position.x - 4, militarSpawn1.transform.position.x + 4), militarSpawn1.transform.position.y, militarSpawn1.transform.position.z);
             else
                 spawnPosition = new Vector3(Random.Range(militarSpawn2.transform.position.x - 4, militarSpawn2.transform.position.x + 4), militarSpawn2.transform.position.y, militarSpawn2.transform.position.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(military[Random.Range(0, military.Length)], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    IEnumerator SpawnActivists()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < activistCount; ++i)
        {
            Vector3 spawnPosition = new Vector3(activistSpawn.transform.position.x, activistSpawn.transform.position.y, activistSpawn.transform.position.z);

            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    IEnumerator SpawnCitizens()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < citizenCount; ++i)
        {
            Vector3 spawnPosition = Vector3.zero;
            int rand = Random.Range(1, 6);
            if (rand > 1.0f && rand <= 2.0f) spawnPosition = new Vector3(citizenSpawn1.transform.position.x, citizenSpawn1.transform.position.y, citizenSpawn1.transform.position.z);                      
            else if (rand > 2.0f && rand <= 3.0f) spawnPosition = new Vector3(citizenSpawn2.transform.position.x, citizenSpawn2.transform.position.y, citizenSpawn2.transform.position.z);                       
            else if (rand > 3.0f && rand <= 4.0f) spawnPosition = new Vector3(citizenSpawn3.transform.position.x, citizenSpawn3.transform.position.y, citizenSpawn3.transform.position.z);                       
            else if (rand > 4.0f && rand <= 5.0f) spawnPosition = new Vector3(citizenSpawn4.transform.position.x, citizenSpawn4.transform.position.y, citizenSpawn4.transform.position.z);                       
            else if (rand > 5.0f && rand <= 6.0f) spawnPosition = new Vector3(citizenSpawn5.transform.position.x, citizenSpawn5.transform.position.y, citizenSpawn5.transform.position.z);                 

            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(citizens[Random.Range(0, citizens.Length)], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}