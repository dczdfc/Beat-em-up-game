using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaceState<EState> where EState : Enum
{
    public BaceState(EState key){
        StateKey = key;
    }
    public EState StateKey {get; private set;}
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract void FixedUpdateState();
    public abstract EState GetNextState();

    
}
