using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class ScreenSetting : MonoBehaviour
{
    [SerializeField] public Volume volume;
    [SerializeField] private Slider ScreenSlider;
    private ColorAdjustments colorAdjustments;
    void Start()
    {
        if (volume != null && volume.profile.TryGet(out ColorAdjustments c))
        {
            colorAdjustments = c;
        }
    }

   public void SetScreen(float volume)
    {
        colorAdjustments.postExposure.value = volume;
    }
}
