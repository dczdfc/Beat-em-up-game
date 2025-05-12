using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRunData", menuName = "Scriptable Objects/PlayerRunData")]
public class PlayerRunData : ScriptableObject
{
    public float moveSpeed;
    public float acceleration;
    public float deceleration;
}
