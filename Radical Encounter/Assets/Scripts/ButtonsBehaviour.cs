using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (GameObject.Find("Game Controller").GetComponent<Money>().Currency >= 2)
            {


                GameObject.Find("Game Controller").GetComponent<Money>().Currency = GameObject.Find("Game Controller").GetComponent<Money>().Currency - 2;

                GameObject.Find("Game Controller").GetComponent<GameController>().activistCount = 2;

                StartCoroutine(GameObject.Find("Game Controller").GetComponent<GameController>().SpawnActivists());

            }
           // Vector3 spawnPosition = new Vector3(activistSpawn.transform.position.x, activistSpawn.transform.position.y, activistSpawn.transform.position.z);

            //Quaternion spawnRotation = Quaternion.identity;
            //Instantiate(activists[Random.Range(0, activists.Length)], spawnPosition, spawnRotation);

        }
    }

    public void Repair()
    {
        if (GameObject.Find("Game Controller").GetComponent<Money>().Currency >= 5)
        {
            if (GoToRepair != null /*&& GoToRepair.GetComponentInParent<DestroyableBuildingsBehaviour>().HP < 150*/)
            {
                GameObject.Find("Game Controller").GetComponent<Money>().Currency = GameObject.Find("Game Controller").GetComponent<Money>().Currency - 5;
                GameObject.Find("Game Controller").GetComponent<Money>().Building++;

                // Find the closes building of the camp
                float distance1 = Mathf.Infinity;
                float distance2 = Mathf.Infinity;
                GameObject[] citizens = GameObject.FindGameObjectsWithTag("Citizens");

                foreach (GameObject currentCitizen in citizens)
                {
                    float newDistance = (currentCitizen.transform.position - GoToRepair.transform.position).magnitude;
                    if (newDistance < distance1)
                    {
                        distance1 = newDistance;
                        currentCitizen.GetComponent<CitizenBehaviour>().buildingToRepair = GoToRepair;
                        currentCitizen.GetComponent<CitizenBehaviour>().mustRepair = true;
                    }
                    else if (newDistance < distance2)
                    {
                        distance2 = newDistance;
                        currentCitizen.GetComponent<CitizenBehaviour>().buildingToRepair = GoToRepair;
                        currentCitizen.GetComponent<CitizenBehaviour>().mustRepair = true;
                    }
                }
            }
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        GameObject Play = FindCHILD("Play");
        GameObject Credits = FindCHILD("Credits");
        GameObject Quit = FindCHILD("Quit");
        GameObject Back = FindCHILD("Back");
        GameObject CreditsText = FindCHILD("Credits Text");
        GameObject Image = FindCHILD("Image");

        Play.SetActive(false);
        Credits.SetActive(false);
        Quit.SetActive(false);
        Back.SetActive(true);
        CreditsText.SetActive(true);
        Image.SetActive(true);
    }

    public void Back()
    {
        GameObject Play = FindCHILD("Play");
        GameObject Credits = FindCHILD("Credits");
        GameObject Quit = FindCHILD("Quit");
        GameObject Back = FindCHILD("Back");
        GameObject CreditsText = FindCHILD("Credits Text");
        GameObject Image = FindCHILD("Image");

        Play.SetActive(true);
        Credits.SetActive(true);
        Quit.SetActive(true);
        Back.SetActive(false);
        CreditsText.SetActive(false);
        Image.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public GameObject FindCHILD(string str)
    {
        foreach (Transform eachChild in transform)
        {
            if (eachChild.name == str)
            {
                return eachChild.gameObject;
            }
        }
        return null;
    }
}
