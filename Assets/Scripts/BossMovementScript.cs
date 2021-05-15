using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovementScript : MonoBehaviour
{
    public static float healthAmount;

    // Start is called before the first frame update
    void Start()
    {
        healthAmount = 30f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            healthAmount -= 0.1f;
        }
    }
}
