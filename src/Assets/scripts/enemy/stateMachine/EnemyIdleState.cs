using UnityEngine;

public class EnemyIdleState : EnemyBaceState
{
    public EnemyIdleState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();
        transPerm[EnemyStateMachine.EEnemyState.Hitten] = true;
        
        
    }
    public override void EnterState(){
        Context.Anim.Play("Idle");
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter EnemyIdleState");
        
    }
    public override void ExitState(){
        Debug.Log("Exit EnemyIdleState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){}
    
    public override EnemyStateMachine.EEnemyState GetNextState(){
        return StateKey;
    }
}
