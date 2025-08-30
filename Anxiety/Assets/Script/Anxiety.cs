using UnityEngine;
public class Anxiety : MonoBehaviour
{
    [SerializeField]private ItemGet itemGet;
    [SerializeField]private PlayerCtrl playerCtrl;
    private SpriteRenderer sr;
    private Rigidbody2D rb;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        ChangeDirection();
        ChangeColor();

        if (playerCtrl.isHold)
        {
            rb.constraints = RigidbodyConstraints2D.None;//zenhoukou move
        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
    }

    void ChangeDirection()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        Vector3 Scale = transform.localScale;
        if (horizontal > 0f)//Right
        {
            Scale.x = Mathf.Abs(Scale.x);
        }
        if (horizontal < 0f)//Left
        {
            Scale.x = -Mathf.Abs(Scale.x);
        }
        transform.localScale = Scale;
    }

    public void ChangeColor()
    {
        switch (itemGet.itemCount)
        {
            case 1:
                sr.color = new Color32(255, 42, 42, 255);
                break;
            case 2:
                sr.color = new Color32(255, 84, 84, 255);
                break;
            case 3:
                sr.color = new Color32(255, 126, 126, 255);
                break;
            case 4:
                sr.color = new Color32(255, 168, 168, 255);
                break;
            case 5:
                sr.color = new Color32(255, 210, 210, 255);
                break;
            case 6:
                sr.color = new Color32(255, 255, 255, 255);
                break;
        }
    }
}
