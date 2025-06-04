using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine : StateManager<EnemyStateMachine.EEnemyState>, IDamagable
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
    [SerializeField] private HelthManager hm;
    [SerializeField] private Transform AttackHitBoxes;
    [SerializeField] private SpriteRenderer spRend;
    [SerializeField] private GroundCheck groundChecker;
    [SerializeField] private PlayerRunData enemyWalkData;
    [SerializeField] private MiniBrains brains;
    [SerializeField] private PlayerAttackData attackLite;
    [SerializeField] private BoxCollider attackLiteArea;
    [SerializeField] private BasicSoundTest basicSoundTest;
    
    public UnityEvent DestroyEvent = new UnityEvent();


    public void Awake()
    {
        hm.MyDamagable = this;
        _context = new EnemyStContext(RB, animator, AttackHitBoxes, spRend, groundChecker, enemyWalkData, brains.walkTrail,
         brains, attackLite, attackLiteArea, basicSoundTest);
        _context.DieEvent.AddListener(RealDie);
        InitializeStates();
    }
    private void InitializeStates()
    {
        States.Add(EEnemyState.Idle, new EnemyIdleState(_context, EEnemyState.Idle));
        States.Add(EEnemyState.Die, new DethState(_context, EEnemyState.Die));
        States.Add(EEnemyState.Walk, new EnemyWalkState(_context, EEnemyState.Walk));
        States.Add(EEnemyState.Hitten, new EnemyHittenState(_context, EEnemyState.Hitten));
        States.Add(EEnemyState.AttackLight, new EnemyAttackLiteState(_context, EEnemyState.AttackLight));



        CurrentState = States[EEnemyState.Idle];
    }
    public void AnimationEvent()
    {
        CurrentState.AnimationEvent();

    }

    public void TakeDamage(hittenData hitDat)
    {
        _context.hitData = hitDat;
        TransToSt(EEnemyState.Hitten);
    }
    public void TransToSt(EnemyStateMachine.EEnemyState eState)
    {
        EnemyBaceState curst = (EnemyBaceState)CurrentState;
        if (curst.transPerm[eState])
        {
            TransitionToState(eState);
        }
        
    }
    public void Attack()
    {
        TransToSt(EEnemyState.AttackLight);
    }
    public bool tryToHit()
    {
        EnemyBaceState curst = (EnemyBaceState)CurrentState;
        if (!curst.transPerm[EnemyStateMachine.EEnemyState.Hitten])
        {
            return false;
        }
        return true;
    }
    public void Die(hittenData hitDat)
    {
        _context.hitData = hitDat;
        TransToSt(EEnemyState.Die);
        
        
    }
    public void RealDie()
    {
        DestroyEvent.Invoke();
        CillStrick.instance.AddKill();
        Destroy(gameObject);
    }
}
