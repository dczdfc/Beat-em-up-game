using UnityEngine;

public class EnBrainContext
{
    private EnemyWalkTrail _walkTrail;
    private EnemyStateMachine _enemyStateMachine;
    private PlayerFounder _plFounder;
    private Transform _myPos;


    public EnBrainContext(EnemyStateMachine enStMach, EnemyWalkTrail enemyWalkTrail, PlayerFounder playerFounder,
    Transform transformPl, Transform MyPos)
    {
        _enemyStateMachine = enStMach;
        _walkTrail = enemyWalkTrail;
        _plFounder = playerFounder;
        playerPoss = transformPl;
        _myPos = MyPos;

    }

    public EnemyStateMachine EnStMach => _enemyStateMachine;
    public EnemyWalkTrail walkTrail => _walkTrail;
    public PlayerFounder plFounder => _plFounder;
    public Transform myPos => _myPos;
    public Transform playerPoss;
}
