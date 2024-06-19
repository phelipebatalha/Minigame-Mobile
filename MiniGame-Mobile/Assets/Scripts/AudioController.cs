using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip musicaDeFundo;
    public static AudioController AudioInstance;
    void Awake()
    {
        if(AudioInstance == null)
        AudioInstance = this;
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
         audioSourceMusicaDeFundo.clip = musicaDeFundo;
         audioSourceMusicaDeFundo.loop = true;
         audioSourceMusicaDeFundo.Play();
    }

}
