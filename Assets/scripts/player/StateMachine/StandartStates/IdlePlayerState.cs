using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IdlePlayerState : PlayerBaceState
{
    public IdlePlayerState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     :base(context, estate){
        Context = context;
        InitPerm();
    }
    private void InitPerm(){
        transPerm.Add(PlayerStateMachine.EPlayerState.Idle, false);
        transPerm.Add(PlayerStateMachine.EPlayerState.Walk, true);
    }
    public override void EnterState(){
        Debug.Log("Enter IdleState");
        
    }
    public override void ExitState(){
        Debug.Log("Exit IdleState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        return GetNextStateBace();

        /*if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            return PlayerStateMachine.EPlayerState.Walk;
        }
        else
        {
            return StateKey;
        }*/
        
        
    }
}
