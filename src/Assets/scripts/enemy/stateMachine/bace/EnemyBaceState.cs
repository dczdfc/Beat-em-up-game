using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public abstract class EnemyBaceState : BaceState<EnemyStateMachine.EEnemyState>
{
    protected EnemyStContext Context;
    public Dictionary<EnemyStateMachine.EEnemyState, bool> transPerm = new Dictionary<EnemyStateMachine.EEnemyState, bool>();
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
        transPerm.Add(EnemyStateMachine.EEnemyState.Die, true);
    }
    public void OverlapDamageArea(PlayerAttackData AttackData, BoxCollider refferBox){
        Vector3 World = refferBox.transform.TransformPoint(refferBox.center);

        Vector3 Scale = refferBox.size /2;

        Collider[] hitColliders = Physics.OverlapBox(World,
         Scale,Quaternion.identity, AttackData.enemyMask);

        foreach (Collider enemy in hitColliders)
        {
            
            HelthManager hethMan = enemy.GetComponent<HelthManager>();
            if (hethMan != null)
            {
                Debug.Log("found!!");
                hethMan.TakeDamage(AttackData, Context.Rb.position);
            }
        }
    }
    public void FlipChar()
    {
        Context.AtHitBxs.rotation = Quaternion.Euler(0, Context.AtHitBxs.rotation.y + 180, 0);
        Context.SprRend.flipX = !Context.SprRend.flipX;
    }
    public void FlipCharR()
    {
        Context.AtHitBxs.rotation = Quaternion.Euler(0, 0, 0);
        Context.SprRend.flipX = false;
    }
    public void FlipCharL()
    {
        Context.AtHitBxs.rotation = Quaternion.Euler(0, 180, 0);
        Context.SprRend.flipX = true;
    }
    public EnemyStateMachine.EEnemyState PermCheck(EnemyStateMachine.EEnemyState tryState)
    {
        if (transPerm[tryState])
        {
            return tryState;
        }
        return StateKey;
    }
    public EnemyStateMachine.EEnemyState GetNextStateBace()
    {
        if (Context.enemyWalkTrail.targetPos != Vector3.zero)
        {
            return PermCheck(EnemyStateMachine.EEnemyState.Walk);
        }else
        {
            return PermCheck(EnemyStateMachine.EEnemyState.Idle);
        }
        return StateKey;
    }
    
}
