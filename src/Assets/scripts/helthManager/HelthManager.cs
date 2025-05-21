using UnityEngine;

public class HelthManager : MonoBehaviour
{
    [SerializeField] private float MaxHelth;
    public IDamagable MyDamagable;
    public float CurrentHelth;
    public void Awake()
    {
        CurrentHelth = MaxHelth;
    }
    public void TakeDamage(PlayerAttackData AttackData, Vector3 atPos)
    {
        Debug.Log("111112");
        if (MyDamagable.tryToHit())
        {
            CurrentHelth -= AttackData.damage;
            hittenData hitdt = new hittenData((atPos - transform.position).normalized, AttackData);

            if (CurrentHelth <= 0)
            {
                MyDamagable.Die(hitdt);
            }
            else
            {
                MyDamagable.TakeDamage(hitdt);
            }

        }

    }

}
public interface IDamagable
{
    bool tryToHit();
    void TakeDamage(hittenData hitDat);
    void Die(hittenData hitDat);
}
