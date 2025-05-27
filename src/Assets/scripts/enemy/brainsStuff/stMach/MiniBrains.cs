using UnityEngine;
using System.Collections;

public class MiniBrains : StateManager<MiniBrains.EBrainStates>
{
    public enum EBrainStates
    {
        Wandering,
        ChasePlayer,
        hitPlayer
    }
    public EnemyWalkTrail walkTrail = new EnemyWalkTrail();
    public EnemyStateMachine enemyStateMachine;
    public PlayerFounder plFounder;
    public Transform playerPos;

    private EnBrainContext _context;


    public void Awake()
    {
        _context = new EnBrainContext(enemyStateMachine, walkTrail, plFounder, playerPos, transform);

        InitializeStates();
    }
    private void InitializeStates()
    {
        States.Add(EBrainStates.Wandering, new WonderingEnState(_context, EBrainStates.Wandering));
        States.Add(EBrainStates.ChasePlayer, new ChasingEnSt(_context, EBrainStates.ChasePlayer));
        States.Add(EBrainStates.hitPlayer, new HitEnSt(_context, EBrainStates.hitPlayer));
        



        CurrentState = States[EBrainStates.Wandering];
    }

    /*IEnumerator RandThings() 
    {
        float buff = 0f;
        while (true)
        {
            PlayerStateMachine playrStMch = plFounder.CheckPlayer();
            if (playrStMch == null) eBrainState = EBrainStates.Wandering;
            else
            {
                playerPos = playrStMch.transform;
                if (Vector3.Distance(walkTrail.targetPos, transform.position) < 2
                && Vector3.Distance(playerPos.position, transform.position) < 4)
                {
                    eBrainState = EBrainStates.hitPlayer;
                    enemyStateMachine.Attack();
                    walkTrail.targetPos = Vector3.zero;
                }
                else
                {
                    eBrainState = EBrainStates.ChasePlayer;
                }
                
                
            }
                
            if (eBrainState == EBrainStates.Wandering)
            {
                int WeStop = Random.Range(0, 2);
                Vector3 RandVect;
                if (WeStop == 0) { buff = 2f; RandVect = Vector3.zero; }
                else { buff = 0f; RandVect = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)); }
                walkTrail.targetPos = RandVect + transform.position;
                Debug.Log(RandVect);
            }
            if (eBrainState == EBrainStates.ChasePlayer)
            {
                buff = -2f;
                int WeLeft = Random.Range(0, 2);

                if (WeLeft == 0)
                {
                    walkTrail.targetPos = playerPos.position - Vector3.left * 2;

                }
                else
                {
                    walkTrail.targetPos = playerPos.position + Vector3.left * 2;
                }
            }if (eBrainState == EBrainStates.hitPlayer)
            {
                enemyStateMachine.Attack();
                walkTrail.targetPos = Vector3.zero;
            }

            yield return new WaitForSeconds(3f + buff);
        }
        
        
    }*/
}
