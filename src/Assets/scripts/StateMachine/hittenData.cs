using UnityEngine;

public class hittenData
{
    public hittenData(Vector3 HitVector0, PlayerAttackData AttackData)
    {
        HitVector = HitVector0;
        Power = AttackData.Power;
        AngPower = AttackData.AngPower;
    }
    public Vector3 HitVector;
    public float Power;
    public float AngPower;
}
