using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource AudioSource;
    private PlayerController player;

    [SerializeField] AudioClip ambientSound;
    [SerializeField] AudioClip baseSound;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        player = PlayerController.getInstance();
    }

    // Update is called once per frame
    void Update()
    {

        if (player.IsInBase)
        {
            PlayBaseSound();
        }
        else
        {
            PlayAmbientSound();
        }



    }

    public void PlayAmbientSound()
    {
        AudioSource.clip = ambientSound;
    }

    public void PlayBaseSound()
    {
        AudioSource.clip = baseSound;
    }
}
