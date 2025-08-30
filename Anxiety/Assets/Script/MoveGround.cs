using UnityEngine;

public class MoveGround : MonoBehaviour
{
    [SerializeField] private Vector3 moveOffset = new Vector3(0, 50f, 0);//moveDis
    [SerializeField] private float speed = 2f;
    private Vector3 startPos;
    private Vector3 targetPos;
    private bool isActive = false;

     void Start()
    {
        startPos = transform.position;
        targetPos = startPos;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
    }

    public void SetState(bool active)
    {
        isActive = active;
        targetPos = isActive ? startPos + moveOffset : startPos;
    }
}
