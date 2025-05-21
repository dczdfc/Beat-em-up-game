using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackData", menuName = "Scriptable Objects/PlayerAttackData")]
public class PlayerAttackData : ScriptableObject
{
    public float damage;
    public float Power;
    public float AngPower;
    public LayerMask enemyMask;
}
