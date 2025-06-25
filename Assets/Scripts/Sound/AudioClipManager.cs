using System.Collections.Generic;
using UnityEngine;
using Utils;

public class AudioClipManager : MonoBehaviour, IMediatorEvent
{
    // ΩÃ±€≈œ¿∏∑Œ »£√‚µ 
    List<AudioClip> _bgmAudio = new List<AudioClip>();
    List<AudioClip> _sfxAudio = new List<AudioClip>();
    SoundController _soundController;

    public void Init()
    {
        CreateSoundController();
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.PlayAudio, this);
        _bgmAudio = GenericSingleton<PrefabManager>.Instance.SoundPrefabLoad.BGMPrefab;
        _sfxAudio = GenericSingleton<PrefabManager>.Instance.SoundPrefabLoad.SFXPrefab;
    }

    void CreateSoundController()
    {
        if(_soundController == null)
            _soundController = GenericSingleton<SoundManager>.Instance.SoundController;
    }

    public void PlayBGM(EBGMType type)
    {
        _soundController.StartBGM(_bgmAudio[(int)type]);
    }

    public void PlaySFX(ESFXType type)
    {
        _soundController.PlaySFXAudio(_sfxAudio[(int)type]);
    }

    public void StopSFX()
    {
        _soundController.StopSFXAudio();
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        if(data is ESFXType sfxType)
            PlaySFX(sfxType);
        else if (data is EBGMType bgmType)
            PlayBGM(bgmType);
    }
}