using UnityEngine;

public class HitEnSt: BraunBaceState
{
    private float MaxTime = 2f;
    float currentTime = 2f;
    private bool Isend = false;
    public HitEnSt(EnBrainContext context, MiniBrains.EBrainStates estate)
     : base(context, estate)
    {
        Context = context;



    }
    public override void EnterState(){
        Context.EnStMach.Attack();
        Context.walkTrail.targetPos = Context.myPos.position;
        
        
    }
    public override void ExitState()
    {
        currentTime = MaxTime;
        Isend = false;
    }
    public override void UpdateState()
    {
        
    }
    public override void FixedUpdateState()
    {
        currentTime -= Time.fixedDeltaTime;
        if (currentTime <= 0)
        {
            Isend = true;
        }
    }
    
    public override MiniBrains.EBrainStates GetNextState(){
        if (Isend)
        {
            return MiniBrains.EBrainStates.Wandering;
        }
        return StateKey;
    }
}
