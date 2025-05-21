using UnityEngine;
using System.Collections;
public class Spowner : MonoBehaviour
{
    public GameObject spObj;
    public Transform[] spPoins;
    public float Delay;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Spown());
    }
    IEnumerator Spown() 
    {
        float buff = 0f;
        while (true)
        {
            int spPNow = Random.Range(0, spPoins.Length);
            Instantiate(spObj, spPoins[spPNow].position, Quaternion.identity);

            yield return new WaitForSeconds(Delay);
        }
        
        
    }
    
}
