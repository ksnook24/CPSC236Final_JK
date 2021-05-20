using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondScript : MonoBehaviour
{
    public GameObject Panel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Destroy(this.gameObject);
            if (Panel != null)
            {
                bool isActive = Panel.activeSelf;
                Panel.SetActive(!isActive);
            }
        }

    }
}
