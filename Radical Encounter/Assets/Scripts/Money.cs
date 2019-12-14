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
        Currency = 15;
        Enemy = 0;
        Ally = 0;
        Citizen = 0;
        Round = 0;
        Camp = 6;
        Building = 15;
    }

    // Update is called once per frame
    void Update()
    {
        Currencies.text = string.Concat("Currency: ", Currency.ToString(), "$");
        Enemies.text = string.Concat("Enemies: ", Enemy.ToString());
        Allies.text = string.Concat("Activists: ", Ally.ToString());
        Citizens.text = string.Concat("Citizens: ", Citizen.ToString());
        Rounds.text = string.Concat("Day ", Round.ToString(), "/5");
        Camps.text = string.Concat("Camps left: ", Camp.ToString());
        Buildings.text = string.Concat("Buildings left: ", Building.ToString());
    }
}
