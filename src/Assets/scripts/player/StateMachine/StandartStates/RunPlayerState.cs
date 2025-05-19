using UnityEngine;

public class RunPlayerState : PlayerBaceState
{
    public RunPlayerState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     :base(context, estate){
        Context = context;
        //InitPerm();
        transPerm[PlayerStateMachine.EPlayerState.Walk] = true;
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
    }
    public override void EnterState(){
        Context.Anim.Play("Run");
        Debug.Log("Enter RunState");
        
    }
    public override void ExitState(){
        Debug.Log("Exit RunState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        


        Vector3 TargetSpeed = moveDirection.normalized * Context.PlRunD.moveSpeed;
        //float accelRateX = (Mathf.Abs(TargetSpeed.x) > 0.01f) ? Context.PlRunD.acceleration : Context.PlRunD.deceleration;
        //float accelRateZ = (Mathf.Abs(TargetSpeed.z) > 0.01f) ? Context.PlRunD.acceleration : Context.PlRunD.deceleration;
        Vector3 speedDif = TargetSpeed - Context.Rb.linearVelocity;
        Vector3 movement = speedDif.x * 10 * Vector3.right + speedDif.z * 10 * Vector3.forward;

        
        Context.Rb.AddForce(movement, ForceMode.Force);
    }
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        return GetNextStateBace();
    }
}
