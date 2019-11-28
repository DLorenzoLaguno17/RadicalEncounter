using UnityEngine;
using NodeCanvas.Framework;

public class RepairBuilding : ActionTask
{
    public GameObject target;

    protected override void OnUpdate()
    {

        EndAction(true);
    }
}