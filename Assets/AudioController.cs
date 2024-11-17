using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    #region singleton region
    public static AudioController Instance { get; private set; }
    public AudioController()
    {
        Instance = this;
    }

    #endregion

    private AudioSource AudioSource;
    private PlayerController player;

    bool inBase = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        timeUnitlNext -= Time.deltaTime;
        if (timeUnitlNext >= 0 && (PlayerController.Instance.IsInBase == inBase)) //check if audioclip ended
        {
            return;
        }
        if (PlayerController.Instance.IsInBase)
        {
            PlayBaseSound();
            inBase = true;
        }
        else
        {
            PlayAmbientSound();
            inBase = false;
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
