using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip hitSound, jumpSound, backgroundSound;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = Resources.Load<AudioClip>("Hit Sound");
        jumpSound = Resources.Load<AudioClip>("Jump Sound");
        backgroundSound = Resources.Load<AudioClip>("Background Sound");

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public static void PlaySound(string clip)
    {
        switch(clip)
        {
            case "hitSound":
                audioSource.PlayOneShot(hitSound);
                break;

            case "jumpSound":
                audioSource.PlayOneShot(jumpSound);
                break;

            case "backgroundSound":
                audioSource.PlayOneShot(backgroundSound);
                break;
        }
    }
}
