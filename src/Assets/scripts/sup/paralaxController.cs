using UnityEngine;

public class paralaxController : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float paralaxEffect;
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;

    }
    void FixedUpdate()
    {
        float distance = cam.transform.position.x * paralaxEffect;
        float movment = cam.transform.position.x * (1 - paralaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movment > startPos +length)
        {
            startPos += length;
        }else if (movment < startPos - length)
        {
            startPos -= length;
        }
    }
}
