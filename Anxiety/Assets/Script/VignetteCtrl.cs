using System.Collections;
using UnityEngine.Rendering.Universal;
using UnityEngine;
using UnityEngine.Rendering;

public class VignetteCtrl : MonoBehaviour
{
    [SerializeField] public Volume volume;
    private Vignette vignette;
    private Coroutine fadeCoroutine;
    void Start()
    {
        if (volume != null && volume.profile.TryGet(out Vignette v))
        {
            vignette = v;
        }
    }
    public void FadeVignetteIntensity(float holdIntensity, float duration)
    {
        fadeCoroutine = StartCoroutine(FadeCoroutine(holdIntensity, duration));
    }

    private IEnumerator FadeCoroutine(float targetValue, float duration)
    {
        float startValue = vignette.intensity.value;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            vignette.intensity.value = Mathf.Lerp(startValue, targetValue, t);
            yield return null;
        }
        vignette.intensity.value = targetValue;
        fadeCoroutine = null;
    }
}
