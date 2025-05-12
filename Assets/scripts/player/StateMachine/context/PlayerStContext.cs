using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStContext
{
    private Rigidbody _rigidbody;
    private PlayerRunData _plWalkData;
    public PlayerStContext(Rigidbody rigidbody, PlayerRunData playerWalkData){
        _rigidbody = rigidbody;
        _plWalkData = playerWalkData;
    }

    public Rigidbody Rb => _rigidbody;
    public PlayerRunData PlWalkD => _plWalkData;
}
