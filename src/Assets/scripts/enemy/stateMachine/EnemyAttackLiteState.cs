using UnityEngine;

public class EnemyAttackLiteState : EnemyBaceState
{
    private bool isEnded = false;
    public EnemyAttackLiteState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();
        transPerm[EnemyStateMachine.EEnemyState.Hitten] = true;
        transPerm[EnemyStateMachine.EEnemyState.Idle] = true;
        transPerm[EnemyStateMachine.EEnemyState.Walk] = true;


    }
    public override void EnterState(){
        Vector3 moveDirection = Context.minBr.playerPos.position - Context.Rb.position;
        if (moveDirection.x > 0) FlipCharR();
        else if (moveDirection.x < 0) FlipCharL();
        
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter EnemyAttackLiteState");
        Context.Anim.Play("Attack");
        
    }
    public override void ExitState()
    {
        Debug.Log("Exit EnemyAttackLiteState");
        isEnded = false;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        if (Context.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
        {
            isEnded = true;
        }
    }
    public override void AnimationEvent()
    {
        
        OverlapDamageArea(Context.AtLite, Context.AtAreaLite);
    }
    
    public override EnemyStateMachine.EEnemyState GetNextState()
    {
        if (isEnded)
        {
            return GetNextStateBace();
        }
        return StateKey;
    }
}

