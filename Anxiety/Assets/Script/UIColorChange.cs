using UnityEngine;
using UnityEngine.UI;

public class UIColorChange : MonoBehaviour
{
    [SerializeField] private ItemGet itemGet;
    private Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    void Update()
    {
        switch (itemGet.itemCount)
        {
            case 1:
                img.color = new Color32(42, 42, 42, 255);
                break;
            case 2:
                img.color = new Color32(84, 84, 84, 255);
                break;
            case 3:
                img.color = new Color32(126, 126, 126, 255);
                break;
            case 4:
                img.color = new Color32(168, 168, 168, 255);
                break;
            case 5:
                img.color = new Color32(210, 210, 210, 255);
                break;
            case 6:
                img.color = new Color32(255, 255, 255, 255);
                break;
        }
    }
}
