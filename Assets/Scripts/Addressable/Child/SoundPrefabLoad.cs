using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SoundPrefabLoad : PrefabLoadBase
{
    GameObject _soundPrefab;
    List<AudioClip> _bgmPrefab = new List<AudioClip>();
    List<AudioClip> _sfxPrefab = new List<AudioClip>();

    public GameObject SoundPrefab { get => _soundPrefab; }
    public List<AudioClip> BGMPrefab { get => _bgmPrefab; }
    public List<AudioClip> SFXPrefab { get => _sfxPrefab; }

    public override async Task LoadPrefab()
    {
        Init();
        _soundPrefab = await _addressableManager.GetAddressableAsset<GameObject>("SoundController");
        //for (int i = 0; i < (int)EBGMType.Max; i++)
        //    _bgmPrefab.Add(await _addressableManager.GetAddressableAsset<AudioClip>($"{(EBGMType)i}"));

        for (int i = 0; i < (int)ESFXType.Max; i++)
        {
            _sfxPrefab.Add(await _addressableManager.GetAddressableAsset<AudioClip>($"{(ESFXType)i}"));
            Debug.Log($"SFX Prefab Loaded: {(ESFXType)i}");
        }
    }
}