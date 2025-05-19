using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStContext
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerRunData _plWalkData;
    private PlayerRunData _plRunData;
    private Transform _attackHitBoxes;
    private SpriteRenderer _spriteRenderer;
    public PlayerStContext(Rigidbody rigidbody, Animator anim, PlayerRunData playerWalkData, PlayerRunData playerRunData,
    Transform attackHitBoxes, SpriteRenderer spriteRenderer)
    {
        _rigidbody = rigidbody;
        _animator = anim;
        _plWalkData = playerWalkData;
        _plRunData = playerRunData;
        _attackHitBoxes = attackHitBoxes;
        _spriteRenderer = spriteRenderer;
    }

    public Rigidbody Rb => _rigidbody;
    public SpriteRenderer SprRend => _spriteRenderer;
    public Transform AtHitBxs => _attackHitBoxes;
    public Animator Anim => _animator;
    public PlayerRunData PlWalkD => _plWalkData;
    public PlayerRunData PlRunD => _plRunData;
}
