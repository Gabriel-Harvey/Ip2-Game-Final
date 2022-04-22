using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadedScene : MonoBehaviour
{
    public PlayerInputHandler playerInput;
    public HeartSystem HeartSystem;
    public Movement movement;
    public GameObject Evangelos;
    public GameObject Angelica;

    public static bool newScene;
    public static int radialcount;

    void Start()
    {
        playerInput = GameObject.FindGameObjectWithTag("PlayerInput").GetComponent<PlayerInputHandler>();
        HeartSystem = GameObject.FindGameObjectWithTag("InputManager").GetComponent<HeartSystem>();
        //movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        playerInput.NewSpawn();
        //movement.NewScene();

        Evangelos = GameObject.Find("Evangelos(Clone)");
        Evangelos.GetComponent<PlayerCollisionMangement>().NewScene();
        Evangelos.GetComponent<Movement>().NewScene();

        Angelica = GameObject.Find("Angelica(Clone)");
        Angelica.GetComponent<PlayerCollisionMangement>().NewScene();
        Angelica.GetComponent<Movement>().NewScene();

        HeartSystem.hearts[0] = GameObject.Find("Heart1");
        HeartSystem.hearts[1] = GameObject.Find("Heart2");
        HeartSystem.hearts[2] = GameObject.Find("Heart3");

        newScene = true;
        HeartSystem.life = 3;
       
    }

    public void Update()
    {
        if (radialcount == 2)
        {
            newScene = false;
        }
    }


}
