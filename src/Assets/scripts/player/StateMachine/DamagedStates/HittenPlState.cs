using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HittenPlState : PlayerBaceState
{
    private bool isFloating = false;
    private bool isEndedFloating = false;
    private float timer = 1.5f;
    public HittenPlState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackLight] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackHeavy] = true;
        Ended = false;
    }
    public override void EnterState(){
        Vector3 htVect = -Context.hitData.HitVector;
        if (Context.hitData.AngPower > 0)
        {
            htVect.y += Context.hitData.AngPower;
            Context.Anim.Play("drop");
            isFloating = true;
            isEndedFloating = false;
        }
        else
        {
            Context.Anim.Play("Hitten");
            isFloating = false;
            isEndedFloating = true;
        }
        htVect.z /= 3;
        Vector3 ForceVect = htVect.normalized * Context.hitData.Power;
        if (ForceVect.x > 0) FlipCharL();
        else if(ForceVect.x < 0) FlipCharR();
        Context.Rb.AddForce(ForceVect);

        //Debug.Log("Enter HittenPlState");
        
        
    }
    public override void ExitState()
    {
        Context.Rb.linearVelocity = Vector3.zero;
        //Debug.Log("Exit HittenPlState");
        Ended = false;
        isEndedFloating = false;
        timer = 1.5f;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        AnimatorStateInfo stateInfo = Context.Anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.99 &&
        (stateInfo.IsName("Hitten") || stateInfo.IsName("drop")))
        {
            Ended = true;
        }
        
        isFloating = !Context.GrChecker.CheckGround();
        if (Ended && !isFloating)
        {
            Context.Anim.Play("land");
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                isEndedFloating = true;
            }
        }
    }
    
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        if (Ended && isEndedFloating)
        {
            return GetNextStateBace();
        }
        return StateKey;
        
    }
}
