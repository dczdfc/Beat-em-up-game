using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHittenState : EnemyBaceState
{
    private bool isEnded = false;
    public EnemyHittenState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[EnemyStateMachine.EEnemyState.Idle] = true;

    }
    public override void EnterState(){
        Context.Anim.Play("Hitten");
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter EnemyHittenState");
        
        
    }
    public override void ExitState(){
        Debug.Log("Exit EnemyHittenState");
        isEnded = false;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        if (Context.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
        {
            isEnded = true;
        }
    }
    
    
    public override EnemyStateMachine.EEnemyState GetNextState(){
        if (isEnded)
        {
            return PermCheck(EnemyStateMachine.EEnemyState.Idle);
        }return StateKey;
        
    }
}
