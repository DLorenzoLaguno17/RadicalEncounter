using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Military spawn variables
    [Header(" -------- Military spawn variables -------- ")]
    public GameObject[] military;
    public Vector3 militarSpawnValues1;
    public Vector3 militarSpawnValues2;
    public int militarCount;

    // Activists spawn variables
    [Header(" -------- Activists spawn variables -------- ")]
    public GameObject[] activists;
    public Vector3 activistSpawnValues;
    public int activistCount;

    // Citizens spawn variables
    [Header(" -------- Citizens spawn variables -------- ")]
    public GameObject[] citizens;
    public Vector3 citizenSpawnValues1;
    public Vector3 citizenSpawnValues2;
    public Vector3 citizenSpawnValues3;
    public Vector3 citizenSpawnValues4;
    public Vector3 citizenSpawnValues5;
    public int citizenCount;

    // Wait times
    [Header(" -------------- Spawn times -------------- ")]
    public float startWait;
    public float spawnWait;
    public float waveWait;

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

        while (true) {
            for (int i = 0; i < militarCount; ++i) {

                Vector3 spawnPosition;
                if (Random.Range(0, 2) < 1.0f)
                    spawnPosition = new Vector3(Random.Range(militarSpawnValues1.x - 4, militarSpawnValues1.x + 4), militarSpawnValues1.y, militarSpawnValues1.z);
                else
                    spawnPosition = new Vector3(Random.Range(militarSpawnValues2.x - 4, militarSpawnValues2.x + 4), militarSpawnValues2.y, militarSpawnValues2.z);

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(military[Random.Range(0, military.Length)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator SpawnActivists()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < activistCount; ++i)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(activistSpawnValues.x - 4, activistSpawnValues.x + 4), activistSpawnValues.y, Random.Range(activistSpawnValues.z - 5, activistSpawnValues.z + 5));
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }

    IEnumerator SpawnCitizens()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < citizenCount; ++i)
            {
                Vector3 spawnPosition = Vector3.zero;
                int rand = Random.Range(1, 6);
                if (rand > 1.0f && rand <= 2.0f) spawnPosition = new Vector3(citizenSpawnValues1.x, citizenSpawnValues1.y, citizenSpawnValues1.z);                      
                else if (rand > 2.0f && rand <= 3.0f) spawnPosition = new Vector3(citizenSpawnValues2.x, citizenSpawnValues2.y, citizenSpawnValues2.z);                       
                else if (rand > 3.0f && rand <= 4.0f) spawnPosition = new Vector3(citizenSpawnValues3.x, citizenSpawnValues3.y, citizenSpawnValues3.z);                       
                else if (rand > 4.0f && rand <= 5.0f) spawnPosition = new Vector3(citizenSpawnValues4.x, citizenSpawnValues4.y, citizenSpawnValues4.z);                       
                else if (rand > 5.0f && rand <= 6.0f) spawnPosition = new Vector3(citizenSpawnValues5.x, citizenSpawnValues5.y, citizenSpawnValues5.z);                 

                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(citizens[Random.Range(0, citizens.Length)], spawnPosition, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            yield return new WaitForSeconds(waveWait);
        }
    }
}