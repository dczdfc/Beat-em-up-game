using UnityEngine;

public class DethState : EnemyBaceState
{
    private bool isEnded = false;
    public DethState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();



    }
    public override void EnterState(){
        Vector3 ForceVect = -Context.hitData.HitVector * Context.hitData.Power;
        if (ForceVect.x > 0) FlipCharL();
        else if(ForceVect.x < 0) FlipCharR();
        
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter DethState");
        Context.Anim.Play("Deth");
        
    }
    public override void ExitState(){
        Debug.Log("Exit DethState");
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
            Context.DieEvent.Invoke();
        }return StateKey;
        
    }
}
