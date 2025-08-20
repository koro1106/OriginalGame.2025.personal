using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private RectTransform rectTransform;
    private Vector3 originalPos;
    private bool isHovering = false;
    public float moveUp = 10f;
    public float moveSpeed = 10f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.localPosition;
    }

    void Update()
    {
        Vector3 targetPos = isHovering ? originalPos + Vector3.up * moveUp : originalPos;

        rectTransform.localPosition =
            Vector3.Lerp(rectTransform.localPosition, targetPos, Time.deltaTime * moveSpeed);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
