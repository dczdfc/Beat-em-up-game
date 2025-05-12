using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class PlayerBaceState : BaceState<PlayerStateMachine.EPlayerState>
{
    protected PlayerStContext Context;
    protected Dictionary<PlayerStateMachine.EPlayerState, bool> transPerm = new Dictionary<PlayerStateMachine.EPlayerState, bool>();
    public PlayerBaceState(PlayerStContext context, PlayerStateMachine.EPlayerState stateKey) : base(stateKey){
        Context = context;
    }
    public PlayerStateMachine.EPlayerState GetNextStateBace(){
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0 && transPerm[PlayerStateMachine.EPlayerState.Walk])
        {
            return PlayerStateMachine.EPlayerState.Walk;
        }else if(Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0 && transPerm[PlayerStateMachine.EPlayerState.Idle])
        {
            return PlayerStateMachine.EPlayerState.Idle;
        }else
        {
            return StateKey;
        }
    }
}
