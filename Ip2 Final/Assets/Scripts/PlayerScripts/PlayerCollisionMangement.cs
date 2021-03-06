using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionMangement : MonoBehaviour
{
    [Header("Lever Detection")]
    [SerializeField]
    Lever lever;
    public bool colliding;
    public bool exitColliding;
    public bool isPressed;
    public PlayerInputHandler inputHandler;
    public Movement movement;
    public HeartSystem heartSystem;
    public static bool Death;

    [Header("Platfrom Lever")]
    public bool leverColliding;
    PlatfromLever platfromLever;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip death;
    public AudioClip soulSound;

    [Header("Portal")]
    SoulsManager souls;
    bool canLeave;
    GameObject EndScreen;

    [Header("Naritive Triggers")]
    public TextTrigger textTrigger;


    private void Start()
    {
        heartSystem = GameObject.FindGameObjectWithTag("InputManager").GetComponent<HeartSystem>();
        souls = GameObject.Find("SoulsManager").GetComponent<SoulsManager>();
        //inputHandler = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInputHandler>();
    }

    private void FixedUpdate()
    {
        if (colliding == true && isPressed == true)
        {
            lever.pulled = true;
        }

        if (exitColliding == true && canLeave == true && isPressed == true)
        {
            //SceneManager.LoadScene("MenuScreen");
            PointsManager.instance.OpenScreen();
        }

        if (leverColliding == true && isPressed == true)
        {
            platfromLever.pulled = true;
        }



    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case ("Death"):
                audioSource.PlayOneShot(death);
                Death = true;
                heartSystem.TakeDamage(1);
                break;

            case ("Soul"):
                audioSource.PlayOneShot(soulSound);
                GameObject.Destroy(collision.gameObject);
                souls.increaseSouls();
                break;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            lever = collision.gameObject.GetComponent<Lever>();
            colliding = true;
        }

        if (collision.gameObject.tag == "PlatformLever")
        {
            platfromLever = collision.gameObject.GetComponent<PlatfromLever>();
            leverColliding = true;
        }

        if (collision.gameObject.tag == "Exit")
        {
            //SceneManager.LoadScene("MenuScreen");
            if (souls.souls == souls.soulMax)
            {
                canLeave = true;
            }
            exitColliding = true;

        }

        if (collision.gameObject.tag == "Checkpoint")
        {
            inputHandler.spawn.gameObject.transform.position = collision.gameObject.transform.position;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
        {
            lever = null;
            colliding = false;
        }

        if (collision.gameObject.tag == "Exit")
        {
            exitColliding = true;

        }

        if (collision.gameObject.tag == "PlatformLever")
        {
            platfromLever = null;
            leverColliding = false;
        }
    }

    public void TextCall()
    {
        inputHandler.trigger = textTrigger;
        inputHandler.paused = true;
    }

    public void NewScene()
    {
        
        heartSystem = GameObject.FindGameObjectWithTag("InputManager").GetComponent<HeartSystem>();
        souls = GameObject.Find("SoulsManager").GetComponent<SoulsManager>();
        Debug.Log("CalledCo");
    }
}

