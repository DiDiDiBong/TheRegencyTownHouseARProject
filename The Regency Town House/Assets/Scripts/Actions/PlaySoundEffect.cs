using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    public AudioSource soundclip;
    // Start is called before the first frame update
    public void PlaySound()
    {
        soundclip.Play();
    }
}
