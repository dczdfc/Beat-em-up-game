using UnityEngine;

public class ChasingEnSt : BraunBaceState
{
    public ChasingEnSt(EnBrainContext context, MiniBrains.EBrainStates estate)
     : base(context, estate)
    {
        Context = context;
        
        
        
    }
    public override void EnterState()
    {

        Context.walkTrail.targetPos = Context.playerPoss.position;
        
        
    }
    public override void ExitState(){
        
    }
    public override void UpdateState()
    {
        if ((Context.playerPoss.position - Context.myPos.position).x < 0)
        {
            Context.walkTrail.targetPos = Context.playerPoss.position + Vector3.right * 2;
        }else
        {
            Context.walkTrail.targetPos = Context.playerPoss.position - Vector3.right * 2;
        }
        
    }
    public override void FixedUpdateState(){}
    
    public override MiniBrains.EBrainStates GetNextState(){
        if (Vector3.Distance(Context.walkTrail.targetPos, Context.myPos.position) < 1)
        {
            return MiniBrains.EBrainStates.hitPlayer;
        }
        return StateKey;
    }
}
