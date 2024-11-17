using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource AudioSource;
    private PlayerController player;

    [SerializeField] AudioClip ambientSound;
    [SerializeField] AudioClip baseSound;

    [SerializeField] AudioClip pickupSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip craftSound;
    [SerializeField] AudioClip feedSound;

    [SerializeField] double timeUnitlNext;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        timeUnitlNext = 0;
        //player = PlayerController.Instance; //UNCOMMENT TODO
    }

    // Update is called once per frame
    void Update()
    {
        timeUnitlNext -= Time.deltaTime;
        if (timeUnitlNext > 0) //check if audioclip ended
        {
            return;
        }
        if (player.IsInBase)
        {
            PlayBaseSound();
        }
        else
        {
            PlayAmbientSound();
        }
    }

    public void WaitForEnd()
    {
        timeUnitlNext = AudioSource.clip.length;
    }

    public void PlayAmbientSound()
    {
        AudioSource.clip = ambientSound;
        AudioSource.Play();
        WaitForEnd();
    }

    public void PlayBaseSound()
    {
        AudioSource.clip = baseSound;
        AudioSource.Play();
        WaitForEnd();
    }

    public void PlayPickupSound()
    {
        AudioSource.clip = pickupSound;
        AudioSource.Play();
        WaitForEnd();
        Update();
    }

    public void PlayDeathSound()
    {
        AudioSource.clip = deathSound;
        AudioSource.Play();
        WaitForEnd();
        Update();
    }

    public void PlayCraftSound()
    {
        AudioSource.clip = craftSound;
        AudioSource.Play();
        WaitForEnd();
        Update();
    }

    public void PlayFeedSound()
    {
        AudioSource.clip = feedSound;
        AudioSource.Play();
        WaitForEnd();
        Update();
    }
}
