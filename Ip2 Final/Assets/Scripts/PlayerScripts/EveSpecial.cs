using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EveSpecial : MonoBehaviour
{
    public Movement movement;
    public Vector2 breakSpeed;
    public AudioClip blockBreak;

    [Header("Player Collision")]
    public Collider2D thisCollider;
    public Collider2D otherCollider;

    [Header("Audio")]
    public AudioClip button;
    public AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Breakable" && movement._rigidbody.velocity.y <= breakSpeed.y)
        {
            audioSource.PlayOneShot(blockBreak);
            GameObject.Destroy(collision.gameObject);   
            Debug.Log("Break");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Button"):
                 audioSource.PlayOneShot(button);
                break;
        }
    }


    public void Update()
    {
        //Physics2D.IgnoreCollision(thisCollider, otherCollider);

    }
    public void Awake()
    {
        //otherCollider = GameObject.Find("Angelica(Clone").GetComponent<CapsuleCollider2D>();
    }
}
