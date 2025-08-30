using UnityEngine.UI;
using UnityEngine;

public class ImageBlinking : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private float duration = 1.3f;

    private Color32 startColor = new Color32(255, 255, 255, 255);
    private Color32 endColor = new Color32(255, 255, 255, 64);
    void Awake()
    {
        if (img == null) img = GetComponent<Image>();
    }

    void Update()
    {
        img.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time / duration, 1.0f));
    }
}
