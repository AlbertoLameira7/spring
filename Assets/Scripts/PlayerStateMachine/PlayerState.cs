using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    protected PlayerController Entity;

    public PlayerState(PlayerController entity)
    {
        Entity = entity;
    }

    public virtual IEnumerator Enter()
    {
        yield break;
    }

    public virtual IEnumerator Update()
    {
        yield break;
    }

    public virtual IEnumerator Exit()
    {
        yield break;
    }
}
