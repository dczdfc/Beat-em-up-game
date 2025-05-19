using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class PlayerBaceState : BaceState<PlayerStateMachine.EPlayerState>
{
    protected PlayerStContext Context;
    protected Dictionary<PlayerStateMachine.EPlayerState, bool> transPerm = new Dictionary<PlayerStateMachine.EPlayerState, bool>();
    public PlayerBaceState(PlayerStContext context, PlayerStateMachine.EPlayerState stateKey) : base(stateKey)
    {
        Context = context;
        InitPerm();
    }
    protected void InitPerm()
    {
        transPerm.Add(PlayerStateMachine.EPlayerState.Idle, false);
        transPerm.Add(PlayerStateMachine.EPlayerState.Walk, false);
        transPerm.Add(PlayerStateMachine.EPlayerState.Run, false);
        transPerm.Add(PlayerStateMachine.EPlayerState.AttackLight, false);
        transPerm.Add(PlayerStateMachine.EPlayerState.AttackHeavy, false);
        transPerm.Add(PlayerStateMachine.EPlayerState.Hitten, true);
        transPerm.Add(PlayerStateMachine.EPlayerState.Die, false);
    }
    public void FlipChar()
    {
        Context.AtHitBxs.rotation = Quaternion.Euler(0, Context.AtHitBxs.rotation.y + 180, 0);
        Context.SprRend.flipX = !Context.SprRend.flipX;
    }
    public void FlipCharR()
    {
        Context.AtHitBxs.rotation = Quaternion.Euler(0, 0, 0);
        Context.SprRend.flipX = false;
    }
    public void FlipCharL()
    {
        Context.AtHitBxs.rotation = Quaternion.Euler(0, 180, 0);
        Context.SprRend.flipX = true;
    }
    public PlayerStateMachine.EPlayerState GetNextStateBace()
    {
        /*if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            if (Input.GetButton("Fire3"))
            {
                if(transPerm[PlayerStateMachine.EPlayerState.Run]) return PlayerStateMachine.EPlayerState.Run;
            }else
            {
                if(transPerm[PlayerStateMachine.EPlayerState.Walk]) return PlayerStateMachine.EPlayerState.Walk;
            }
            
        }else if(Input.GetButton("Fire1")){
            if(transPerm[PlayerStateMachine.EPlayerState.AttackLight]) return PlayerStateMachine.EPlayerState.AttackLight;
        }
        else
        {
            if(transPerm[PlayerStateMachine.EPlayerState.Idle]) return PlayerStateMachine.EPlayerState.Idle;
        }
        return StateKey;*/


        if (!Input.GetButton("Fire3") && Input.GetButton("Jump"))
        {
            return PermCheck(PlayerStateMachine.EPlayerState.AttackLight);
        }
        else if (!Input.GetButton("Fire3") && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            return PermCheck(PlayerStateMachine.EPlayerState.Walk);
        }
        else if (Input.GetButton("Fire3") && (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0))
        {
            return PermCheck(PlayerStateMachine.EPlayerState.Run);
        }
        else if ((Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0))
        {
            return PermCheck(PlayerStateMachine.EPlayerState.Idle);
        }
        else
        {
            return StateKey;
        }
    }
    public PlayerStateMachine.EPlayerState PermCheck(PlayerStateMachine.EPlayerState tryState)
    {
        if (transPerm[tryState])
        {
            return tryState;
        }
        return StateKey;
    }
}
