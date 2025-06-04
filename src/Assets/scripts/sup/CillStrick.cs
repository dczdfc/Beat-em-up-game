using UnityEngine;
using UnityEngine.UI;

public class CillStrick : MonoBehaviour
{
    private int cillStrick = 0;
    public Text KillStr;
    public static CillStrick instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void AddKill()
    {
        cillStrick += 1;
        KillStr.text = "kills = " + cillStrick.ToString();
    }
    public void Deackivate()
    {
        Destroy(gameObject);
    }
}
