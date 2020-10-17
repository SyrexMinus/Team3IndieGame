using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // function off sound in audio system on MainCamera
    public void SoundOff()
    {
        AudioListener.volume = 0.0f;
    }
    // function on sound in audio system on MainCamera
    public void SoundOn()
    {
        AudioListener.volume = 1.0f;
    }
}
