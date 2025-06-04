using UnityEngine;

public class DethPlState : PlayerBaceState
{

    public DethPlState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();
        Ended = false;



    }
    public override void EnterState(){
        Vector3 ForceVect = -Context.hitData.HitVector * Context.hitData.Power;
        if (ForceVect.x > 0) FlipCharL();
        else if(ForceVect.x < 0) FlipCharR();
        
        Context.Rb.linearVelocity = Vector3.zero;
        //Debug.Log("Enter DethState");
        Context.Anim.Play("deth");
        
    }
    public override void ExitState(){
        //Debug.Log("Exit DethState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        AnimatorStateInfo stateInfo = Context.Anim.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.normalizedTime >= 0.9 && stateInfo.IsName("deth") )
        {
            Ended = true;
        }
    }
    
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        if (Ended)
        {
            Context.DieEvent.Invoke();
        }return StateKey;
        
    }
}
