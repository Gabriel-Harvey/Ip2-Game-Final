using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public void Start()
    {
        if (GameObject.Find("Main Camera Track"))
        {
            //Debug.Log("Found");
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = false;
        }
        else
        {
            //Debug.Log("Not found");
            GameObject.Find("Main Camera").GetComponent<AudioListener>().enabled = true;

        }
    }

    public void Levels()
    {
        SceneManager.LoadScene("MenuScreen");
    }

    public void startGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
