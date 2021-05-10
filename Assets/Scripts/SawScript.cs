using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawScript : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.transform.position = respawnPoint.position;
        }
    }
}
