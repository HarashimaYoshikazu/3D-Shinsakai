using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField,Tooltip("このオブジェクトのAudioSource")]
    AudioSource _audioSource;
    public AudioSource Audio => _audioSource;

    [SerializeField, Tooltip("選ぶ時のSE")]
    AudioClip _selectSound;
    public AudioClip SelectSound => _selectSound;

    [SerializeField,Tooltip("タイトルのBGM")]
    AudioClip _titleBGM;
    public AudioClip TitleBGM => _titleBGM;

    [SerializeField, Tooltip("装備を着る音")]
    AudioClip _equipSE;
    public AudioClip EqipSE => _equipSE;

    [SerializeField, Tooltip("装備を脱ぐ音")]
    AudioClip _takeOffSE;
    public AudioClip TakeOffSE => _takeOffSE;

    [SerializeField, Tooltip("敵が死ぬ音")]
    AudioClip _enemyDeathSE;
    public AudioClip EnemyDeathSE => _enemyDeathSE;

    public void SoundPlay(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void OnClick()
    {
        _audioSource.PlayOneShot(_selectSound);
    }
}
