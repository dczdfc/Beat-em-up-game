using UnityEngine;

public class PlayerAttackHeavy : PlayerBaceState
{
    
    public PlayerAttackHeavy(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackLight] = true;
        Ended = false;
    }
    public override void EnterState(){
        Context.Anim.Play("SAttack");
        AudioManager.instance.PlaySoundFXClip(Context.bST.Attack2, Context.Rb.position, 0.1f);
        Context.Rb.linearVelocity = Vector3.zero;
        //Debug.Log("Enter PlayerAttackHeavy");
        
        
    }
    public override void ExitState(){
        //Debug.Log("Exit PlayerAttackHeavy");
        Ended = false;
    }
    public override void AnimationEvent()
    {
        OverlapDamageArea(Context.AtHeavy, Context.AtAreaHeavy);
    }
    public override void UpdateState() { }
    public override void FixedUpdateState()
    {
        
        AnimatorStateInfo stateInfo = Context.Anim.GetCurrentAnimatorStateInfo(0);
        
        if (stateInfo.normalizedTime >= 0.99 && stateInfo.IsName("SAttack") )
        {
            Ended = true;
        }
    }
    
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        return GetNextStateBace();
    }
}
