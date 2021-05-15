using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletController : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 1;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        BossMovement enemy = hitInfo.GetComponent<BossMovement>();
        if (enemy != null)
        {
            enemy.TakeDamange(damage);
            Destroy(gameObject);
        }
    }
}
