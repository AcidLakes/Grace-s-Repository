using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{
    public Slider Volume;
    public AudioSource mySEMusic;

    // Update is called once per frame
    void Update()
    {
        mySEMusic.volume = Volume.value;
    }
}
