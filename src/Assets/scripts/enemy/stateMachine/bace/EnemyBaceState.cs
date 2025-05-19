using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class EnemyBaceState : BaceState<EnemyStateMachine.EEnemyState>
{
    protected EnemyStContext Context;
    protected Dictionary<EnemyStateMachine.EEnemyState, bool> transPerm = new Dictionary<EnemyStateMachine.EEnemyState, bool>();
    public EnemyBaceState(EnemyStContext context, EnemyStateMachine.EEnemyState stateKey) : base(stateKey)
    {
        Context = context;
        InitPerm();
    }
    protected void InitPerm()
    {
        transPerm.Add(EnemyStateMachine.EEnemyState.Idle, false);
        transPerm.Add(EnemyStateMachine.EEnemyState.Walk, false);
        transPerm.Add(EnemyStateMachine.EEnemyState.AttackLight, false);
        transPerm.Add(EnemyStateMachine.EEnemyState.Hitten, false);
        transPerm.Add(EnemyStateMachine.EEnemyState.Die, false);
    }
    public EnemyStateMachine.EEnemyState PermCheck(EnemyStateMachine.EEnemyState tryState)
    {
        if (transPerm[tryState])
        {
            return tryState;
        }
        return StateKey;
    }
}
