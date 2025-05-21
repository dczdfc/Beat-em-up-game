using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStContext
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Transform _attackHitBoxes;
    private GroundCheck _groundChecker;
    private PlayerRunData _enWalkData;
    private MiniBrains _miniBrains;
    private PlayerAttackData _attackLite;
    private BoxCollider _attackLiteArea;


    public EnemyStContext(Rigidbody rigidbody, Animator anim, Transform attackHitBoxes, SpriteRenderer spriteRenderer,
    GroundCheck groundChecker, PlayerRunData enemyWalkData, EnemyWalkTrail eenemyWalkTrail, MiniBrains miniBrains,
    PlayerAttackData attackLite, BoxCollider attackLiteArea)
    {
        _rigidbody = rigidbody;
        _animator = anim;
        _attackHitBoxes = attackHitBoxes;
        _spriteRenderer = spriteRenderer;
        _groundChecker = groundChecker;
        _enWalkData = enemyWalkData;
        _miniBrains = miniBrains;
        _attackLite = attackLite;
        _attackLiteArea = attackLiteArea;
        enemyWalkTrail = eenemyWalkTrail;

    }

    public PlayerAttackData AtLite => _attackLite;
    public BoxCollider AtAreaLite => _attackLiteArea;
    public Rigidbody Rb => _rigidbody;
    public MiniBrains minBr => _miniBrains;
    public GroundCheck GrChecker => _groundChecker;

    public Animator Anim => _animator;
    public SpriteRenderer SprRend => _spriteRenderer;
    public Transform AtHitBxs => _attackHitBoxes;
    public PlayerRunData enWalkDt => _enWalkData;

    public hittenData hitData;
    public EnemyWalkTrail enemyWalkTrail;
    public UnityEvent DieEvent = new UnityEvent();
    
}
