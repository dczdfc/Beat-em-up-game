using UnityEngine;

public class PlayerAttackLite1State : PlayerBaceState
{
    private bool isEnded = false;
    public PlayerAttackLite1State(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     :base(context, estate){
        Context = context;
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
    }
    public override void EnterState(){
        Context.Anim.Play("Attack");
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter AttackLite1State");
        
        
    }
    public override void ExitState(){
        Debug.Log("Exit AttackLite1State");
        isEnded = false;
    }
    public override void UpdateState(){}
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
