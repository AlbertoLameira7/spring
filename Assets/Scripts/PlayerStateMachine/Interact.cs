using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : PlayerState
{
    public Interact(PlayerController entity) : base(entity)
    {
    }

    public override IEnumerator Enter()
    {
        Entity.Target.GetComponent<GardenTile>().UseTile();
        yield return new WaitForSeconds(0f);
    }

    public override IEnumerator Update()
    {
        yield return new WaitForSeconds(0f);
    }

    public override IEnumerator Exit()
    {
        yield return new WaitForSeconds(0f);
    }
}
