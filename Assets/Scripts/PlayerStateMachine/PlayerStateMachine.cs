using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerStateMachine : MonoBehaviour
{
    protected PlayerState playerState;

    public void SetState(PlayerState state)
    {
        if (playerState != null)
        {
            StartCoroutine(playerState.Exit());
        }

        playerState = state;
        StartCoroutine(playerState.Enter());
    }

    public void UpdateState()
    {
        StartCoroutine(playerState.Update());
    }
}
