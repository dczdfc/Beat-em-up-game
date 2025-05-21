using UnityEngine;

public class PlayerAttackHeavy : PlayerBaceState
{
    private bool isEnded = false;
    public PlayerAttackHeavy(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     : base(context, estate)
    {
        Context = context;
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
        transPerm[PlayerStateMachine.EPlayerState.AttackLight] = true;
    }
    public override void EnterState(){
        Context.Anim.Play("SAttack");
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter PlayerAttackHeavy");
        
        
    }
    public override void ExitState(){
        Debug.Log("Exit PlayerAttackHeavy");
        isEnded = false;
    }
    public override void AnimationEvent()
    {
        OverlapDamageArea(Context.AtHeavy, Context.AtAreaHeavy);
    }
    public override void UpdateState() { }
    public override void FixedUpdateState(){
        if (Context.Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9)
        {
            isEnded = true;
        }
    }
    
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        if (isEnded)
        {
            return GetNextStateBace();
        }return StateKey;
        
    }
}
