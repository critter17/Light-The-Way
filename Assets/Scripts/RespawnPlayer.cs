using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interact")
        {
            GameObject player = collision.transform.parent.gameObject;
            player.transform.position = spawnPoint.position;
        }
    }
}
