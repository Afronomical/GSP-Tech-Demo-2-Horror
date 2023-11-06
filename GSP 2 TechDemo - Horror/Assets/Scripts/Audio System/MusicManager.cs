using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource source;
    private static MusicManager instance;
    public AudioClip defaultClip;

    private void Awake()
    {
        MusicManager.instance = this;
    }
    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip= defaultClip;
        source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayMusic(AudioClip clip)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }

        source.clip = clip;
        source.Play();
    }

}
