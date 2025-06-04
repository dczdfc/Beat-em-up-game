using UnityEngine;

public class diePanel : MonoBehaviour
{
    
    public void RestatrtLevl()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
