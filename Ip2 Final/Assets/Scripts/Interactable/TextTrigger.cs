using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public PlayerCollisionMangement collisionMangement;
    public GameObject textBox;
    public static bool xPessed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collisionMangement = collision.gameObject.GetComponent<PlayerCollisionMangement>();
            collisionMangement.textTrigger = this;
            collisionMangement.TextCall();
            textBox.SetActive(true);
            Time.timeScale = 0;
        }

        
    }

    public void Update()
    {
        /*if(xPessed == true)
        {
            textBox.SetActive(false);
            xPessed = false;
        }*/
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

    public void DestroyText()
    {
        Time.timeScale = 1;
        textBox.SetActive(false);
    }

}
