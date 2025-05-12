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
    [SerializeField] private PlayerRunData WalkData;
    public void Awake(){
        _context = new PlayerStContext(RB, WalkData);
        InitializeStates();
    }
    private void InitializeStates(){
        States.Add(EPlayerState.Idle, new IdlePlayerState(_context, EPlayerState.Idle));
        States.Add(EPlayerState.Walk, new WalkPlayerState(_context, EPlayerState.Walk));
        
        CurrentState =States[EPlayerState.Idle];
    }
}
