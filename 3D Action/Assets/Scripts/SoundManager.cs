using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : DDOLSingleton<SoundManager>
{
    [SerializeField,Tooltip("このオブジェクトのAudioSource")]
    AudioSource _audioSource;


    [SerializeField, Tooltip("選ぶ時のSE")]
    AudioClip _selectSound;
    public AudioClip SelectSound => _selectSound;

    [SerializeField,Tooltip("タイトルのBGM")]
    AudioClip _titleBGM;
    public AudioClip TitleBGM => _titleBGM;

    public void SoundPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
