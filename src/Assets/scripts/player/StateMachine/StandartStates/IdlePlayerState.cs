using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IdlePlayerState : PlayerBaceState
{
    public IdlePlayerState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackLight] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackHeavy] = true;
        
    }
    public override void EnterState(){
        Context.Anim.Play("idle");
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter IdleState");
        
    }
    public override void ExitState(){
        Debug.Log("Exit IdleState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        return GetNextStateBace();
    }
}
