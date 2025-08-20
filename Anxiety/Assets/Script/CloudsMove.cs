using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsMove : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float endPos= -13.0f;
    [SerializeField] private float startPos= 22.0f;
  
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if(transform.position.x < endPos)
        {
            Vector3 pos = transform.position;
            pos.x = startPos;
            transform.position = pos;
        }
    }
}
