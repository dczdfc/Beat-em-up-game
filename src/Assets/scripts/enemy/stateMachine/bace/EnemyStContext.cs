using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStContext
{
    private Rigidbody _rigidbody;
    private Animator _animator;

    public EnemyStContext(Rigidbody rigidbody, Animator anim)
    {
        _rigidbody = rigidbody;
        _animator = anim;

    }

    public Rigidbody Rb => _rigidbody;
    public Animator Anim => _animator;
    
}
