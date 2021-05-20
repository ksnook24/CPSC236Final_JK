using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondKeyController : MonoBehaviour
{
    private Text keyText;
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        keyText = GameObject.Find("KeyText").GetComponent<Text>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            collision.gameObject.GetComponent<PlayerMovement>().hasSecondKey = true;
            Destroy(this.gameObject);
            UpdateScore();
        }
    }

    public void UpdateScore()
    {
        keyText.GetComponent<KeyScoreManager>().score += 1;
        keyText.GetComponent<KeyScoreManager>().UpdateScore();
        NotificationOpener();
    }

    public void NotificationOpener()
    {
        if (keyText.GetComponent<KeyScoreManager>().score == 2)
        {
            if (Panel != null)
            {
                bool isActive = Panel.activeSelf;
                Panel.SetActive(!isActive);
            }
        }
        else
        {

        }
    }
}
