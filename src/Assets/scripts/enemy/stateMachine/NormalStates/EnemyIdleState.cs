using UnityEngine;

public class EnemyIdleState : EnemyBaceState
{
    public EnemyIdleState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();
        transPerm[EnemyStateMachine.EEnemyState.Hitten] = true;
        transPerm[EnemyStateMachine.EEnemyState.Walk] = true;
        transPerm[EnemyStateMachine.EEnemyState.AttackLight] = true;
        
        
    }
    public override void EnterState(){
        
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter EnemyIdleState");
        Context.Anim.Play("Idle");
        
    }
    public override void ExitState(){
        Debug.Log("Exit EnemyIdleState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override EnemyStateMachine.EEnemyState GetNextState(){
        return GetNextStateBace();
    }
}
