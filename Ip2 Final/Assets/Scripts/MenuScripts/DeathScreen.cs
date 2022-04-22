using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Start()
    {
        
        //Destroy(GameObject.Find("Evangelos(Clone)"));
        //Destroy(GameObject.Find("Angelica(Clone)"));
        //Destroy(GameObject.Find("Main Camera Track"));
        //Destroy(GameObject.Find("Player(Clone)"));
        //Destroy(GameObject.Find("Player(Clone)"));

    }
}
