using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class EnemyHittenState : EnemyBaceState
{
    private bool isEnded = false;
    private bool isFloating = false;
    private bool isEndedFloating = false;
    private float timer = 1.5f;
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
        AudioManager.instance.PlaySoundFXClip(Context.bST.Hitten, Context.Rb.position, 0.2f);
        if (Context.hitData.AngPower > 0)
        {
            htVect.y += Context.hitData.AngPower;
            Context.Anim.Play("Drop");
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
        Debug.Log("Enter EnemyHittenState");
        
        
        
        
        
        
        
    }
    public override void ExitState()
    {
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Exit EnemyHittenState");
        isEnded = false;
        isEndedFloating = false;
        timer = 1.5f;
    }
    public override void UpdateState()
    {
        
    }
    
    public override void FixedUpdateState()
    {
        AnimatorStateInfo stateInfo = Context.Anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 0.99 &&
        (stateInfo.IsName("Hitten") || stateInfo.IsName("Drop")))
        {
            isEnded = true;
        }

        isFloating = !Context.GrChecker.CheckGround();
        if (isEnded && !isFloating)
        {
            Context.Anim.Play("land");
            timer -= Time.fixedDeltaTime;
            if (timer <= 0)
            {
                isEndedFloating = true;
            }
        }
    }
    
    
    
    public override EnemyStateMachine.EEnemyState GetNextState()
    {
        if (isEnded && isEndedFloating)
        {
            return GetNextStateBace();
        }
        return StateKey;

    }
}
