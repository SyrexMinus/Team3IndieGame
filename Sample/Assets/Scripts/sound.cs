using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    AudioSource soundPlay;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void PlaySound()
    {
        soundPlay = GetComponent<AudioSource>();
        soundPlay.Play();
    }
    // Update is called once per frame
    void Update()
    {
    }
}
