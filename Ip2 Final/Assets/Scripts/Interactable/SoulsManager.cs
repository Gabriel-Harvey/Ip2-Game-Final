using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoulsManager : MonoBehaviour
{
    public int souls;
    public int soulMax;
    public GameObject SoulsCounter;
    Text txt;

    public void Start()
    {
        txt = SoulsCounter.gameObject.GetComponent<Text>();
    }
    public void increaseSouls()
    {
        souls++;
        txt.text = "" + souls;
    }
}
