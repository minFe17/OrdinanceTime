using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] protected AudioSource _bgm;
    [SerializeField] protected List<AudioSource> _sfxAudio;

    GameOverSound _gameOverSound = new GameOverSound();

    int _index;

    public AudioSource BGM { get { return _bgm; } }
    public List<AudioSource> SFXAudio { get { return _sfxAudio; } }

    private void Start()
    {
        _gameOverSound.Init(this);
    }

    public void PlaySFXAudio(AudioClip audio)
    {
        _sfxAudio[_index].clip = audio;
        _sfxAudio[_index].Play();
        _index++;
        if (_index == _sfxAudio.Count)
            _index = 0;
    }

    public void StopSFXAudio()
    {
        _sfxAudio[_index - 1].Stop();
    }

    public void StartBGM(AudioClip audio)
    {
        _bgm.clip = audio;
        _bgm.Play();
    }

    public void StopBGM()
    {
        _bgm.Stop();
    }

    public void GameOverSound()
    {
        StopBGM();
    }
}