using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject anxiety;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = new Vector3(-1250, -273, 0);
            anxiety.transform.position = new Vector3(-1240, -272, 0);
        }
    }
    void PlayerRespawn()
    {

    }
}
