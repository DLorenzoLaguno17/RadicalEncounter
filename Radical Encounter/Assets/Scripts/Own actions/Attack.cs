using UnityEngine;
using NodeCanvas.Framework;

public class Attack : ActionTask
{
    public GameObject target;
    MonoBehaviour behaviour;

    protected override string OnInit()
    {
        if(agent.tag == "Military")
            behaviour = agent.gameObject.GetComponent<MilitaryBehaviour>();
        else if(agent.tag == "Activist")
            behaviour = agent.gameObject.GetComponent<ActivistBehaviour>();

        return null;
    }

    protected override void OnUpdate()
    {
        
        EndAction(true);
    }
}