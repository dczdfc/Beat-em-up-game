using UnityEngine;
using System.Collections;
public class Spowner : MonoBehaviour
{
    public GameObject spObj;
    public Transform[] spPoins;
    public float MaxTime = 3f;
    float CurTime = 3f;
    public void FixedUpdate()
    {
        CurTime -= Time.fixedDeltaTime;
        if (CurTime <= 0)
        {
            Spown();
            CurTime = MaxTime;
        }
    }
    public void Spown()
    {
        int spPNow = Random.Range(0, spPoins.Length);
        Instantiate(spObj, spPoins[spPNow].position, Quaternion.identity);
    }
    
}
