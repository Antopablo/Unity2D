
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider mSlider;

    public Gradient mGradient;
    public Image mFill;

    public void setMaxHealth(int _health)
    {
        mSlider.maxValue = _health;
        mSlider.value = _health;

        mFill.color = mGradient.Evaluate(1f);    
    }

    public void setHealth(int _health)
    {
        mSlider.value = _health;

        mFill.color = mGradient.Evaluate(mSlider.normalizedValue);
    }
}
