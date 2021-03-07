using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : PlayerState
{
    public Walk(PlayerController entity) : base(entity)
    {
    }

    public override IEnumerator Enter()
    {
        Vector3 lookAtAngle = new Vector3(Entity.Destination.x, Entity.transform.position.y, Entity.Destination.z);
        Entity.transform.LookAt(lookAtAngle);
        Entity.NavMeshAgentComponent.destination = Entity.Destination;
        Entity.isWalking = true;
        yield return new WaitForSeconds(0f);
    }

    public override IEnumerator Update()
    {
        if (!Entity.NavMeshAgentComponent.pathPending)
        { 
            if (Entity.NavMeshAgentComponent.remainingDistance <= Entity.NavMeshAgentComponent.stoppingDistance)
            {
                if (!Entity.NavMeshAgentComponent.hasPath || Entity.NavMeshAgentComponent.velocity.sqrMagnitude == 0f)
                {
                    Entity.SetState(new Idle(Entity));
                }
            }
        }
        yield return new WaitForSeconds(0f);
    }

    public override IEnumerator Exit()
    {
        Entity.isWalking = false;
        yield return new WaitForSeconds(0f);
    }
}
