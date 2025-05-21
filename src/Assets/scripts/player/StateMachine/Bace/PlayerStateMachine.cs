using UnityEngine;

public class PlayerStateMachine : StateManager<PlayerStateMachine.EPlayerState>, IDamagable
{
    public enum EPlayerState
    {
        Idle,
        Walk,
        Run,
        AttackLight,
        AttackHeavy,
        Hitten,
        Die
    }
    private PlayerStContext _context;
    [SerializeField] private Rigidbody RB;
    [SerializeField] private HelthManager hm;
    [SerializeField] private Transform AttackHitBoxes;
    [SerializeField] private SpriteRenderer spRend;
    [SerializeField] private BoxCollider attackLite1Area;

    [SerializeField] private Animator animator;
    [SerializeField] private PlayerRunData WalkData;
    [SerializeField] private PlayerRunData RunData;
    [SerializeField] private PlayerAttackData AttackLite1;

    [SerializeField] private PlayerAttackData AttackHeavy;
    [SerializeField] private BoxCollider attackHeavyArea;

    public void Awake()
    {
        hm.MyDamagable = this;
        _context = new PlayerStContext(RB, animator, WalkData, RunData, AttackHitBoxes, spRend,
         attackLite1Area, AttackLite1, AttackHeavy, attackHeavyArea);
        InitializeStates();
    }
    private void InitializeStates()
    {
        States.Add(EPlayerState.Idle, new IdlePlayerState(_context, EPlayerState.Idle));
        States.Add(EPlayerState.Walk, new WalkPlayerState(_context, EPlayerState.Walk));
        States.Add(EPlayerState.Run, new RunPlayerState(_context, EPlayerState.Run));
        States.Add(EPlayerState.AttackLight, new PlayerAttackLite1State(_context, EPlayerState.AttackLight));
        States.Add(EPlayerState.AttackHeavy, new PlayerAttackHeavy(_context, EPlayerState.AttackHeavy));
        States.Add(EPlayerState.Hitten, new HittenPlState(_context, EPlayerState.Hitten));



        CurrentState = States[EPlayerState.Idle];
    }
    public void AnimationEvent()
    {
        CurrentState.AnimationEvent();

    }

    public void TakeDamage(hittenData hitDat)
    {

        TransitionToState(EPlayerState.Hitten);

    }
    public bool tryToHit()
    {
        /*PlayerBaceState curst = (PlayerBaceState)CurrentState;
        if (!curst.transPerm[PlayerStateMachine.EPlayerState.Hitten])
        {
            return false;
        }*/
        return true;
    }
    public void Die(hittenData hitDat)
    {
        Destroy(gameObject);
    }
}
