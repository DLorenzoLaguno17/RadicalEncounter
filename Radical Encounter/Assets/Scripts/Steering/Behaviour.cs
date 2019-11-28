using System.Collections;
using UnityEngine;

static class Constants
{
    public const int prioritiesNumber = 5;
}

abstract public class Behaviour : MonoBehaviour
{
    [Range(0, Constants.prioritiesNumber)]
    public int priority = 0;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {

    }
}