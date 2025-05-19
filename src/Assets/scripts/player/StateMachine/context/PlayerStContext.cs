using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStContext
{
    private Rigidbody _rigidbody;
    private Animator _animator;
    private PlayerRunData _plWalkData;
    private PlayerRunData _plRunData;
    public PlayerStContext(Rigidbody rigidbody,Animator anim, PlayerRunData playerWalkData, PlayerRunData playerRunData){
        _rigidbody = rigidbody;
        _animator = anim;
        _plWalkData = playerWalkData;
        _plRunData = playerRunData;
    }

    public Rigidbody Rb => _rigidbody;
    public Animator Anim => _animator;
    public PlayerRunData PlWalkD => _plWalkData;
    public PlayerRunData PlRunD => _plRunData;
}
