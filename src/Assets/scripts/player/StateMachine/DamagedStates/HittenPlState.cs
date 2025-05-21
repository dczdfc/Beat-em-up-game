using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HittenPlState : PlayerBaceState
{
    private bool isEnded = false;
    public HittenPlState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackLight] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackHeavy] = true;
    }
    public override void EnterState(){
        Context.Anim.Play("Hitten");
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter HittenPlState");
        
        
    }
    public override void ExitState(){
        Debug.Log("Exit HittenPlState");
        isEnded = false;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        if (Context.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
        {
            isEnded = true;
        }
    }
    
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        if (isEnded)
        {
            return GetNextStateBace();
        }return StateKey;
        
    }
}
