using UnityEngine;

public class EnemyWalkState : EnemyBaceState
{
    public EnemyWalkState(EnemyStContext context, EnemyStateMachine.EEnemyState estate)
     : base(context, estate)
    {
        Context = context;
        //InitPerm();
        transPerm[EnemyStateMachine.EEnemyState.Hitten] = true;
        transPerm[EnemyStateMachine.EEnemyState.Idle] = true;
        transPerm[EnemyStateMachine.EEnemyState.AttackLight] = true;
        
        
    }
    public override void EnterState(){
        
        Context.Rb.linearVelocity = Vector3.zero;
        Debug.Log("Enter EnemyWalkState");
        Context.Anim.Play("Walk");
        
    }
    public override void ExitState(){
        Debug.Log("Exit EnemyWalkState");
    }
    public override void UpdateState(){}
    public override void FixedUpdateState(){
        Vector3 moveDirection = Context.enemyWalkTrail.targetPos - Context.Rb.position;  //new Vector3(Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical"));
        // куда смотрим?
        if (moveDirection.x > 0) FlipCharR();
        else if (moveDirection.x < 0) FlipCharL();
        


        Vector3 TargetSpeed = moveDirection.normalized * Context.enWalkDt.moveSpeed;
        Vector3 speedDif = TargetSpeed - Context.Rb.linearVelocity;
        Vector3 movement = speedDif.x * 10 * Vector3.right + speedDif.z * 10 * Vector3.forward;

        
        Context.Rb.AddForce(movement, ForceMode.Force);
    }
    
    public override EnemyStateMachine.EEnemyState GetNextState(){
        return GetNextStateBace();
    }
}
