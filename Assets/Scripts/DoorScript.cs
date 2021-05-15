using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform doorRespawnPoint;
    public PlayerMovement player;

    private void Start()
    {
        PlayerMovement player = GetComponent<PlayerMovement>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (player.hasFirstKey == true && player.hasSecondKey == true)
        {
            if (collision.gameObject.layer == 9)
            {
                collision.gameObject.transform.position = doorRespawnPoint.position;
            }
        }
    }
}
