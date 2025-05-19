using UnityEngine;

public class PlayerStateMachine : StateManager<PlayerStateMachine.EPlayerState>
{
    public enum EPlayerState
    {
        Idle,
        Walk,
        Run,
        AttackLight,
        AttackHeavy,
        TakeDamage,
        Die
    }
    private PlayerStContext _context;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerRunData WalkData;
    [SerializeField] private PlayerRunData RunData;
    public void Awake(){
        _context = new PlayerStContext(RB,animator, WalkData, RunData);
        InitializeStates();
    }
    private void InitializeStates(){
        States.Add(EPlayerState.Idle, new IdlePlayerState(_context, EPlayerState.Idle));
        States.Add(EPlayerState.Walk, new WalkPlayerState(_context, EPlayerState.Walk));
        States.Add(EPlayerState.Run, new RunPlayerState(_context, EPlayerState.Run));
        States.Add(EPlayerState.AttackLight, new PlayerAttackLite1State(_context, EPlayerState.AttackLight));


        CurrentState =States[EPlayerState.Idle];
    }
}
