using UnityEngine;

public abstract class BraunBaceState : BaceState<MiniBrains.EBrainStates>
{
    protected EnBrainContext Context;
    public BraunBaceState(EnBrainContext context, MiniBrains.EBrainStates stateKey) : base(stateKey)
    {
        Context = context;
    }
    
}
