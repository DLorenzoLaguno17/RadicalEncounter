using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public Text text;
    public int Currency;


    // Start is called before the first frame update
    void Start()
    {
        Currency = 20;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Concat(Currency.ToString(), "$");
    }
}
