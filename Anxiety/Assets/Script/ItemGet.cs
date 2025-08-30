using UnityEngine;

public class ItemGet : MonoBehaviour
{
    public int itemCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            itemCount++;
        }
    }
}
