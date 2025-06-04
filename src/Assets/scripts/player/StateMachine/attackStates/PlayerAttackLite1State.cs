using UnityEngine;

public class PlayerAttackLite1State : PlayerBaceState
{
    public PlayerAttackLite1State(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackHeavy] = true;
        
        
        Ended = false;

        transUpperPerm[PlayerStateMachine.EPlayerState.AttackHeavy] = true;
    }
    public override void EnterState(){
        Context.Anim.Play("Attack");
        AudioManager.instance.PlaySoundFXClip(Context.bST.Attack1, Context.Rb.position, 0.1f);
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter AttackLite1State");
        
        
    }
    public override void ExitState(){
        //Debug.Log("Exit AttackLite1State");
        Ended = false;
    }
    public override void AnimationEvent()
    {
        //Debug.Log("attackLiteEvent");
        OverlapDamageArea(Context.At1Lite, Context.AtAreaLite1);
    }
    public override void UpdateState() { }
    public override void FixedUpdateState(){
        AnimatorStateInfo stateInfo = Context.Anim.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.normalizedTime >= 0.8 && stateInfo.IsName("Attack") )
        {
            Ended = true;
        }
    }
    
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        return GetNextStateBace();
    }
}
