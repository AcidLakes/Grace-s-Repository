using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteController : MonoBehaviour
{
    public void mute()
    {
        AudioListener.pause = !AudioListener.pause;
    }
}
