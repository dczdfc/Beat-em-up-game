using UnityEngine;

public class PlayerFounder : MonoBehaviour
{
    public bool HavePlayer = false;
    private SphereCollider sphereCollider;
    public LayerMask PlayerMask;
    public PlayerStateMachine playerrr;
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();

    }
    
    public PlayerStateMachine CheckPlayer()
    {
        HavePlayer = true;
        Collider[] hitColliders = Physics.OverlapSphere(transform.TransformPoint(sphereCollider.center),
        sphereCollider.radius, PlayerMask);
        if (hitColliders.Length > 0)
        {
            HavePlayer = true;
        }
        else
        {
            HavePlayer = false;
        }
        if (HavePlayer)
        {
            return hitColliders[0].GetComponent<PlayerStateMachine>();
        }
        return null;

    }
}
