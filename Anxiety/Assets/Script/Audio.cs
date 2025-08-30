using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    [SerializeField] Slider BGMSlider;
    [SerializeField] Slider SESlider;
    void Start()
    {
        //BGM
        audioMixer.GetFloat("BGM", out float bgmVolome);
        BGMSlider.value = bgmVolome;
        //SE
        audioMixer.GetFloat("SE", out float seVolome);
        SESlider.value = seVolome;
    }


    public void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", volume);
    }
    public void SetSE(float volume)
    {
        audioMixer.SetFloat("SE", volume);
    }
}
