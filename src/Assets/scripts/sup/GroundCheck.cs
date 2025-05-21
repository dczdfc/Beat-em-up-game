using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = true;
    private SphereCollider sphereCollider;
    public LayerMask GroundMask;
    private void Awake()
    {
        sphereCollider = GetComponent<SphereCollider>();

    }
    public bool CheckGround()
    {
        isGrounded = true;
        Collider[] hitColliders = Physics.OverlapSphere(transform.TransformPoint(sphereCollider.center),
        sphereCollider.radius, GroundMask);
        if (hitColliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        return isGrounded;
        
    }
}
