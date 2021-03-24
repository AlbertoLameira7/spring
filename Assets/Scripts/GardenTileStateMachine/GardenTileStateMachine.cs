using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenTileStateMachine : MonoBehaviour
{
    protected GardenTileState gardenTileState;

    public void SetState(GardenTileState state)
    {
        if (gardenTileState != null)
        {
            gardenTileState.Exit();
        }

        gardenTileState = state;
        gardenTileState.Enter();
    }

    public void UpdateState()
    {
        gardenTileState.Update();
    }
}
