using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Vocals : MonoBehaviour
{
    private AudioSource source;
    public static Vocals Instance;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void Say(AudioObject clip)
    {
        if (source.isPlaying)
        {
            source.Stop();
        }

        source.PlayOneShot(clip.clip);

        UIManager.instance.SetSubtitle(clip.subtitle, clip.clip.length);
    }
}
