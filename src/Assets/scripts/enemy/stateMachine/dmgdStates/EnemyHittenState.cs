using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyHittenState : EnemyBaceState
{
    private bool isEnded = false;
    private bool isFloating = false;
    public EnemyHittenState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[EnemyStateMachine.EEnemyState.Idle] = true;
        transPerm[EnemyStateMachine.EEnemyState.Hitten] = false;
        transPerm[EnemyStateMachine.EEnemyState.Walk] = true;
        transPerm[EnemyStateMachine.EEnemyState.AttackLight] = true;

    }
    public override void EnterState(){
        //Context.Rb.linearVelocity = Vector3.zero;

        Vector3 htVect = -Context.hitData.HitVector;
        if (Context.hitData.AngPower > 0)
        {
            htVect.y += Context.hitData.AngPower;
            Context.Anim.Play("Drop");
            isFloating = true;
        }
        else
        {
            Context.Anim.Play("Hitten");
            isFloating = false;
        }
        htVect.z /= 3;
        Vector3 ForceVect = htVect.normalized * Context.hitData.Power;
        if (ForceVect.x > 0) FlipCharL();
        else if(ForceVect.x < 0) FlipCharR();
        Context.Rb.AddForce(ForceVect);
        Debug.Log("Enter EnemyHittenState");
        
        
        
        
        
        
        
    }
    public override void ExitState(){
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Exit EnemyHittenState");
        isEnded = false;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        if (Context.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
        {
            isEnded = true;
        }
        
        isFloating = !Context.GrChecker.CheckGround();
    }
    
    
    public override EnemyStateMachine.EEnemyState GetNextState(){
        if (isEnded && !isFloating)
        {
            return GetNextStateBace();
        }return StateKey;
        
    }
}
