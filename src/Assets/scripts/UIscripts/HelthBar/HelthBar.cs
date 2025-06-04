using UnityEngine;
using UnityEngine.UI;
public class HelthBar : MonoBehaviour
{
    public Slider slider;
    public void SetMaxHelth(int Helth)
    {
        slider.maxValue = Helth;
        SetHelth(Helth);
    }
    public void SetHelth(int Helth)
    {
        slider.value = Helth;
    }
}
