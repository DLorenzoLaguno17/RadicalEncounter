﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBuildingsBehaviour : MonoBehaviour
{
    public int HP;
    GameObject FULL;
    GameObject HALF;
    GameObject NONE;
    Collider BBOX;
    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        HP = 150;
        FULL = FindCHILD("FULL");
        HALF = FindCHILD("HALF");
        NONE = FindCHILD("NONE");

        BBOX = FULL.GetComponent<Collider>();
        mesh = FULL.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(HP > 100)
        {
            mesh.enabled = true;
            HALF.SetActive(false);
            NONE.SetActive(false);

        }
        else if(HP > 50 && HP < 100)
        {
            HALF.SetActive(true);
            NONE.SetActive(false);
            mesh.enabled = false;
        }
        else if(HP < 50 && HP >= 0)
        {
            NONE.SetActive(true);
            HALF.SetActive(false);
            mesh.enabled = false;
        }
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
