using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTileState : MonoBehaviour
{
    protected GardenTile Entity;

    public GardenTileState(GardenTile entity)
    {
        Entity = entity;
    }

    public virtual void Enter()
    {
    }

    public virtual void Update()
    {
    }

    public virtual void Exit()
    {
    }
}
