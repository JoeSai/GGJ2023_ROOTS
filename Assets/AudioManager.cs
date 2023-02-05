using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private Dictionary<string, AudioClip> soundEffects;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        soundEffects = new Dictionary<string, AudioClip>();
        AudioClip[] clips = Resources.LoadAll<AudioClip>("SoundEffects");
        foreach (AudioClip clip in clips)
        {
            soundEffects.Add(clip.name, clip);
        }
    }

    public void PlaySoundEffectByName(string name)
    {
        if (soundEffects.ContainsKey(name))
        {
            AudioSource source = new GameObject(name).AddComponent<AudioSource>();
            source.clip = soundEffects[name];
            source.Play();
            Destroy(source.gameObject, source.clip.length);
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlaySoundEffectByName("Click");
        }
    }

}
