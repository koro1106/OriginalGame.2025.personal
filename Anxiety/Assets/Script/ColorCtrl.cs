using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ColorCtrl : MonoBehaviour
{
    [SerializeField] public Volume volume;
    [SerializeField] public float duration = 0.5f;
    [SerializeField] public float maxExposure;
    [SerializeField] public float minExposure;
    private ColorAdjustments colorAdjustments;
    private Coroutine coroutine;
    private MenuCtrl menuCtrl;

    private PlayerCtrl playerCtrl;

    void Start()
    {
        if (volume != null && volume.profile.TryGet(out ColorAdjustments c))
        {
            colorAdjustments = c;
        }

        playerCtrl = GetComponent<PlayerCtrl>();
        menuCtrl = GetComponent<MenuCtrl>();
    }

    private void Update()
    {
        if (menuCtrl.isMenuOpne)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                coroutine = null;
            }
            if (colorAdjustments != null)
            {
                colorAdjustments.postExposure.value = 0f;
            }
            return;
        }
        else if (!playerCtrl.isHold && coroutine == null)
        {
            coroutine = StartCoroutine(LoopExposure());
        }
        else if (playerCtrl.isHold && coroutine != null)
        {
            StopCoroutine(LoopExposure());
            coroutine = null;
        }
    }
    IEnumerator LoopExposure()
    {
        while (!playerCtrl.isHold)
        {
            //Down 0 -> -1
            yield return StartCoroutine(ChangeExposre(maxExposure,minExposure,duration));
            //Up -1 -> 0
            yield return StartCoroutine(ChangeExposre(minExposure, maxExposure, duration));
        }
    }

    IEnumerator ChangeExposre(float from, float to, float time)
    {
        float elapsed = 0;
        while(elapsed < time)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / time;
            colorAdjustments.postExposure.value = Mathf.Lerp(from, to, t);
            yield return null;
        }
        colorAdjustments.postExposure.value = to;
    }
}
