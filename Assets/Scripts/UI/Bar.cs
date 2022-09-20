using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : MonoBehaviour
{
    [SerializeField] protected Slider Slider;
    public void OnValueChange(int value, int maxValue)
    {
        Slider.value = (float)value / maxValue;
    }
}
