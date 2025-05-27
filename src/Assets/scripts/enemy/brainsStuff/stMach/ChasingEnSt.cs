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
        Context.EnStMach.Attack();
        
    }
    public override void ExitState(){
        
    }
    public override void UpdateState()
    {
        
    }
    public override void FixedUpdateState(){}
    
    public override MiniBrains.EBrainStates GetNextState(){
        if (Vector3.Distance(Context.walkTrail.targetPos, Context.myPos.position) < 2)
        {
            return MiniBrains.EBrainStates.hitPlayer;
        }
        return StateKey;
    }
}
