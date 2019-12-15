using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public GameObject activistSpawn1;
    public GameObject activistSpawn2;
    public GameObject activistSpawn3;
    public GameObject activistSpawn4;
    public GameObject activistSpawn5;
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

    int roundComparer;
    bool playSound = true;

    // Start is called before the first frame update
    void Start()
    {
        citizenCount = 5;
        militarCount = 5;
        roundComparer = 1;
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnActivists());
        StartCoroutine(SpawnCitizens());
    }

    private void Update()
    {
        RoundControl();
        LoseCondition();
        WinCondition();
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < militarCount; ++i) {

            Vector3 spawnPosition;
            if (Random.Range(0, 2) < 1.0f)
                 spawnPosition = new Vector3(Random.Range(militarSpawn1.transform.position.x - 5, militarSpawn1.transform.position.x + 5), militarSpawn1.transform.position.y, militarSpawn1.transform.position.z);
             else
                 spawnPosition = new Vector3(Random.Range(militarSpawn2.transform.position.x - 5, militarSpawn2.transform.position.x + 5), militarSpawn2.transform.position.y, militarSpawn2.transform.position.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(military[Random.Range(0, military.Length)], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(10.0f);
        }
    }

    public IEnumerator SpawnActivists()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < activistCount; ++i)
        {

            Vector3 spawnPosition = Vector3.zero;
            if (i % 5 == 0) spawnPosition = new Vector3(activistSpawn1.transform.position.x, activistSpawn1.transform.position.y, activistSpawn1.transform.position.z);
            else if (i % 4 == 0) spawnPosition = new Vector3(activistSpawn2.transform.position.x, activistSpawn2.transform.position.y, activistSpawn2.transform.position.z);
            else if (i % 3 == 0) spawnPosition = new Vector3(activistSpawn3.transform.position.x, activistSpawn3.transform.position.y, activistSpawn3.transform.position.z);
            else if (i % 2 == 0) spawnPosition = new Vector3(activistSpawn4.transform.position.x, activistSpawn4.transform.position.y, activistSpawn4.transform.position.z);
            else spawnPosition = new Vector3(activistSpawn5.transform.position.x, activistSpawn5.transform.position.y, activistSpawn5.transform.position.z);

            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    public void Recruit()
    {
        Vector3 spawnPosition = Vector3.zero;
        Quaternion spawnRotation = Quaternion.identity;

        spawnPosition = new Vector3(activistSpawn1.transform.position.x, activistSpawn1.transform.position.y, activistSpawn1.transform.position.z);
        Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);

        spawnPosition = new Vector3(activistSpawn5.transform.position.x, activistSpawn5.transform.position.y, activistSpawn5.transform.position.z);
        Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);
    }

    IEnumerator SpawnCitizens()
    {
        yield return new WaitForSeconds(startWait);

        for (int i = 0; i < citizenCount; ++i)
        {
            Vector3 spawnPosition = Vector3.zero;            
            if (i % 5 == 0) spawnPosition = new Vector3(citizenSpawn1.transform.position.x, citizenSpawn1.transform.position.y, citizenSpawn1.transform.position.z);                      
            else if (i % 4 == 0) spawnPosition = new Vector3(citizenSpawn2.transform.position.x, citizenSpawn2.transform.position.y, citizenSpawn2.transform.position.z);                       
            else if (i % 3 == 0) spawnPosition = new Vector3(citizenSpawn3.transform.position.x, citizenSpawn3.transform.position.y, citizenSpawn3.transform.position.z);                       
            else if (i % 2 == 0) spawnPosition = new Vector3(citizenSpawn4.transform.position.x, citizenSpawn4.transform.position.y, citizenSpawn4.transform.position.z);                       
            else spawnPosition = new Vector3(citizenSpawn5.transform.position.x, citizenSpawn5.transform.position.y, citizenSpawn5.transform.position.z);                 

            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(citizens[Random.Range(0, citizens.Length)], spawnPosition, spawnRotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }

    void RoundControl()
    {
       if(roundComparer != GameObject.Find("Game Controller").GetComponent<Money>().Round) {
            
            //Handle enemies
            if(GameObject.Find("Game Controller").GetComponent<Money>().Round == 2)
            {
                militarCount = 8;
                StartCoroutine(SpawnEnemies());
            }
            else if (GameObject.Find("Game Controller").GetComponent<Money>().Round == 3)
            {
                militarCount = 12;
                StartCoroutine(SpawnEnemies());
            }
            else if (GameObject.Find("Game Controller").GetComponent<Money>().Round == 4)
            {
                militarCount = 17;
                StartCoroutine(SpawnEnemies());
            }
            else if (GameObject.Find("Game Controller").GetComponent<Money>().Round == 5)
            {
                militarCount = 23;
                StartCoroutine(SpawnEnemies());
            }

            // Handle citizens
            if (GameObject.Find("Game Controller").GetComponent<Money>().Building - GameObject.Find("Game Controller").GetComponent<Money>().Citizen - 7 > 0)
                citizenCount = (GameObject.Find("Game Controller").GetComponent<Money>().Building - GameObject.Find("Game Controller").GetComponent<Money>().Citizen - 7);
            else if (GameObject.Find("Game Controller").GetComponent<Money>().Building - GameObject.Find("Game Controller").GetComponent<Money>().Citizen -7 <= 0)
                citizenCount = 0;

            StartCoroutine(SpawnCitizens());

            roundComparer = GameObject.Find("Game Controller").GetComponent<Money>().Round;
        }
    }

    public void LoseCondition()
    {
        if(GameObject.Find("Game Controller").GetComponent<Money>().Camp <= 0 /*|| GameObject.Find("Game Controller").GetComponent<Money>().Citizen <= 0*/)
        {
            // Activate background
            GameObject.Find("UICanvas").transform.GetChild(12).gameObject.SetActive(true);

            // Activate main menu
            GameObject.Find("UICanvas").transform.GetChild(13).gameObject.SetActive(true);

            // Activate "You Lose"
            GameObject.Find("UICanvas").transform.GetChild(15).gameObject.SetActive(true);

            if (playSound)
            {
                GameObject.Find("UICanvas").transform.GetChild(15).gameObject.GetComponent<AudioSource>().Play();
                playSound = false;
            }

            DisableUI();
        }
    }

    public void WinCondition()
    {
        if (GameObject.Find("Game Controller").GetComponent<Money>().Round >= 5 && GameObject.Find("Game Controller").GetComponent<Money>().Enemy <= 0)
        {
            // Activate background
            GameObject.Find("UICanvas").transform.GetChild(12).gameObject.SetActive(true);

            // Activate main menu
            GameObject.Find("UICanvas").transform.GetChild(13).gameObject.SetActive(true);

            // Activate "You Win"
            GameObject.Find("UICanvas").transform.GetChild(14).gameObject.SetActive(true);

            if (playSound)
            {
                GameObject.Find("UICanvas").transform.GetChild(14).gameObject.GetComponent<AudioSource>().Play();
                playSound = false;
            }

            DisableUI();
        }
    }

    void DisableUI()
    {
        GameObject.Find("UICanvas").transform.GetChild(0).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(1).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(2).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(3).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(4).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(5).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(6).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(7).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(8).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(9).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(10).gameObject.SetActive(false);
        GameObject.Find("UICanvas").transform.GetChild(11).gameObject.SetActive(false);
    }
}