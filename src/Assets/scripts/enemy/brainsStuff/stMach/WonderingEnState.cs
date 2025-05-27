using UnityEngine;
using System.Collections;

public class WonderingEnState: BraunBaceState
{
    private float MaxTimeToWonder = 3f;
    private bool IsWalking = false;
    float CurrentTime = 0f;
    public WonderingEnState(EnBrainContext context, MiniBrains.EBrainStates estate)
     : base(context, estate)
    {
        Context = context;



    }
    public override void EnterState(){
        
        
        
    }
    public override void ExitState(){
        Context.walkTrail.targetPos = Context.myPos.position;
    }
    public override void UpdateState(){}
    public override void FixedUpdateState()
    {
        if (CurrentTime <= 0)
        {
            float bonus = 0f;
            Vector3 RandVect;
            if (IsWalking)
            {
                RandVect = Vector3.zero;
                bonus += 2f;
                IsWalking = false;
            }
            else
            {
                RandVect = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
                
                IsWalking = true;
            }
            Context.walkTrail.targetPos = RandVect + Context.myPos.position;
            CurrentTime = MaxTimeToWonder + bonus;
        }else
        {
            CurrentTime -= Time.fixedDeltaTime;
        }
    }
    
    public override MiniBrains.EBrainStates GetNextState(){
        PlayerStateMachine playrStMch = Context.plFounder.CheckPlayer();
        if (playrStMch != null)
        {
            Context.playerPoss = playrStMch.transform;
            return MiniBrains.EBrainStates.ChasePlayer;
        }
        return StateKey;
    }
}

