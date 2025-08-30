using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
public class PlCamera: MonoBehaviour
{
    [SerializeField]public GameObject target;
    [SerializeField] public float minX, maxX;
    [SerializeField] public float minY, maxY;

    public Vector3 offset = new Vector3(0,0,-10);//CameraPositionOffset
    public float cameraSpeed = 5f;
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is nill!");
            return;
        }
        Vector3 cameraPos = target.transform.position + offset;
        cameraPos.x = Mathf.Clamp(cameraPos.x, minX, maxX);
        cameraPos.y = Mathf.Clamp(cameraPos.y, minY, maxY);
        transform.position = Vector3.Lerp(transform.position, cameraPos, cameraSpeed * Time.deltaTime);
    }
}
