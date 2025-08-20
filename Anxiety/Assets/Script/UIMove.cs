using UnityEngine;

public class UIMove : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float endPos = -13.0f;
    [SerializeField] private float startPos = 22.0f;

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }
    void Update()
    {
        Vector2 pos = rect.anchoredPosition;
        pos.x -= speed * Time.deltaTime;

        if (pos.x < endPos)
        {
            pos.x = startPos;
        }
        rect.anchoredPosition = pos;
    }
}