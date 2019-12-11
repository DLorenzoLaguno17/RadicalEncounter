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

        Play.SetActive(false);
        Credits.SetActive(false);
        Quit.SetActive(false);
        Back.SetActive(true);
        CreditsText.SetActive(true);
    }

    public void Back()
    {
        GameObject Play = FindCHILD("Play");
        GameObject Credits = FindCHILD("Credits");
        GameObject Quit = FindCHILD("Quit");
        GameObject Back = FindCHILD("Back");
        GameObject CreditsText = FindCHILD("Credits Text");

        Play.SetActive(true);
        Credits.SetActive(true);
        Quit.SetActive(true);
        Back.SetActive(false);
        CreditsText.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
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
