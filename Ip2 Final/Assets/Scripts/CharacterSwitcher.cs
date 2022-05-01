using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterSwitcher : MonoBehaviour
{
    public static CharacterSwitcher Instance;
    public GameObject LvlButton;
    public int index = 0;
    public int imageIndex;
    public GameObject[] Playerimages;
    public void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    public void Update()
    {
        
        if(imageIndex == 2)
        {
            imageIndex = 0;
            LvlButton.SetActive(true);
        }
    }

    public void SwitchCharacterSpawn(PlayerInput input)
    {

        StartCoroutine(WaitTimerCourotine());
        Playerimages[imageIndex].SetActive(true);
        imageIndex++;
    }

    IEnumerator WaitTimerCourotine()
    {
        yield return new WaitForSeconds(0.1f);
        index = 1;
    }

}
