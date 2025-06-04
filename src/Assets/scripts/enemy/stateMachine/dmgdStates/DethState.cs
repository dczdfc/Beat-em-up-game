using UnityEngine;

public class DethState : EnemyBaceState
{
    public DethState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();



    }
    public override void EnterState(){
        Vector3 ForceVect = -Context.hitData.HitVector * Context.hitData.Power;
        AudioManager.instance.PlaySoundFXClip(Context.bST.die, Context.Rb.position, 0.2f);
        if (ForceVect.x > 0) FlipCharL();
        else if (ForceVect.x < 0) FlipCharR();
        
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter DethState");
        Context.Anim.Play("Deth");
        
    }
    public override void ExitState(){
        Debug.Log("Exit DethState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        AnimatorStateInfo stateInfo = Context.Anim.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.normalizedTime >= 0.9 && stateInfo.IsName("Deth") )
        {
            
            Context.DieEvent.Invoke();
        }
    }
    
    
    public override EnemyStateMachine.EEnemyState GetNextState(){
        return StateKey;
        
    }
}
