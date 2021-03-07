using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : PlayerState
{
    public Idle(PlayerController entity) : base(entity)
    {
    }

    public override IEnumerator Enter()
    {
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
