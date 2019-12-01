using UnityEngine;
using NodeCanvas.Framework;

public class CheckAttack : ConditionTask
{
    protected override bool OnCheck()
    {
        float rand = Random.Range(0.0f, 10.0f);

        if (rand < 5.0f) return true;
        else return false;
    }
}