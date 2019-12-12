using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text Currencies, Enemies, Allies, Citizens, Rounds, Camps, Buildings;
    public int Currency, Enemy, Ally, Citizen, Round, Camp, Building;


    // Start is called before the first frame update
    void Start()
    {
        Currency = 20;
        Enemy = 5;
        Ally = 3;
        Citizen = 7;
        Round = 2;
        Camp = 3;
        Building = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Currencies.text = string.Concat("Currency: ",Currency.ToString(), "$");
        Enemies.text = string.Concat("Enemies: ", Enemy.ToString());
        Allies.text = string.Concat("Activists: ", Ally.ToString());
        Citizens.text = string.Concat("Citizens: ", Citizen.ToString());
        Rounds.text = string.Concat("Day ", Round.ToString(), "/5");
        Camps.text = string.Concat("Camps left: ", Camp.ToString());
        Buildings.text = string.Concat("Buildings left: ", Building.ToString());
    }
}
