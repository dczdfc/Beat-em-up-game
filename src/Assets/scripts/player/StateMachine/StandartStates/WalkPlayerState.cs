using UnityEngine;

public class WalkPlayerState : PlayerBaceState
{
    public WalkPlayerState(PlayerStContext context, PlayerStateMachine.EPlayerState estate)
     :base(context, estate){
        Context = context;
        //InitPerm();
        transPerm[PlayerStateMachine.EPlayerState.Idle] = true;
        transPerm[PlayerStateMachine.EPlayerState.Run] = true;
    }
    
    public override void EnterState(){
        Context.Anim.Play("Walk");
        Debug.Log("Enter WalkState");
        
    }
    public override void ExitState(){
        Debug.Log("Exit WalkState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        Vector3 moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        


        Vector3 TargetSpeed = moveDirection.normalized * Context.PlWalkD.moveSpeed;
        //float accelRateX = (Mathf.Abs(TargetSpeed.x) > 0.01f) ? Context.PlWalkD.acceleration : Context.PlWalkD.deceleration;
        //float accelRateZ = (Mathf.Abs(TargetSpeed.z) > 0.01f) ? Context.PlWalkD.acceleration : Context.PlWalkD.deceleration;
        Vector3 speedDif = TargetSpeed - Context.Rb.linearVelocity;
        Vector3 movement = speedDif.x * 10 * Vector3.right + speedDif.z * 10 * Vector3.forward;

        
        Context.Rb.AddForce(movement, ForceMode.Force);
    }
    
    public override PlayerStateMachine.EPlayerState GetNextState(){
        return GetNextStateBace();
    }
}
