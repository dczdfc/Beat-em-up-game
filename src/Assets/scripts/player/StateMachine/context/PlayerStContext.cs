using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStContext
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerRunData _plWalkData;
    private PlayerRunData _plRunData;
    private Transform _attackHitBoxes;
    private SpriteRenderer _spriteRenderer;
    private BoxCollider _attackLite1Area;
    private PlayerAttackData _attack1Lite;
    private BoxCollider _attackHeavyArea;
    private PlayerAttackData _attackHeavy;
    private GroundCheck _groundChecker;
    private BasicSoundTest _bsSounTest;
    public PlayerStContext(Rigidbody rigidbody, Animator anim, PlayerRunData playerWalkData, PlayerRunData playerRunData,
    Transform attackHitBoxes, SpriteRenderer spriteRenderer, BoxCollider AttackLite1Area, PlayerAttackData attack1Lite,
    PlayerAttackData attackHeavy, BoxCollider AttackHeavyArea, GroundCheck groundChecker, BasicSoundTest basicSoundTest)
    {
        _rigidbody = rigidbody;
        _animator = anim;
        _plWalkData = playerWalkData;
        _plRunData = playerRunData;
        _attackHitBoxes = attackHitBoxes;
        _spriteRenderer = spriteRenderer;
        _attackLite1Area = AttackLite1Area;
        _attack1Lite = attack1Lite;
        _attackHeavy = attackHeavy;
        _attackHeavyArea = AttackHeavyArea;
        _groundChecker = groundChecker;
        _bsSounTest = basicSoundTest;
    }

    public Rigidbody Rb => _rigidbody;
    public BasicSoundTest bST => _bsSounTest;
    public PlayerAttackData At1Lite => _attack1Lite;
    public BoxCollider AtAreaLite1 => _attackLite1Area;

    public PlayerAttackData AtHeavy => _attackHeavy;
    public BoxCollider AtAreaHeavy => _attackHeavyArea;
    public SpriteRenderer SprRend => _spriteRenderer;
    public Transform AtHitBxs => _attackHitBoxes;
    public Animator Anim => _animator;
    public GroundCheck GrChecker => _groundChecker;
    public hittenData hitData;

    public PlayerRunData PlWalkD => _plWalkData;
    public PlayerRunData PlRunD => _plRunData;
    public UnityEvent DieEvent = new UnityEvent();
}
