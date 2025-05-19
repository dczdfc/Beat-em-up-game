using UnityEngine;

public class EnemyStateMachine : StateManager<EnemyStateMachine.EEnemyState>
{
    public enum EEnemyState
    {
        Idle,
        Walk,
        AttackLight,
        Hitten,
        Die
    }
    private EnemyStContext _context;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Animator animator;

    public void Awake()
    {
        _context = new EnemyStContext(RB, animator);
        InitializeStates();
    }
    private void InitializeStates()
    {
        States.Add(EEnemyState.Idle, new EnemyIdleState(_context, EEnemyState.Idle));
        States.Add(EEnemyState.Hitten, new EnemyHittenState(_context, EEnemyState.Hitten));
        


        CurrentState = States[EEnemyState.Idle];
    }
    
    public void TakeDamage()
    {
       TransitionToState(EEnemyState.Hitten);
    }
}
