using UnityEngine;
using UnityEngine.Events;

public class AnimationsMethods : MonoBehaviour
{
    public UnityEvent AnimEvent;

    public void Attack1Lite()
    {
        AnimEvent.Invoke();
    }
    
}
