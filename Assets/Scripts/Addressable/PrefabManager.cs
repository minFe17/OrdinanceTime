using System.Threading.Tasks;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    SoundPrefabLoad _soundPrefabLoad = new SoundPrefabLoad();
    UIPrefabLoad _uiPrefabLoad = new UIPrefabLoad();
    NinjaPrefabLoad _ninjaPrefabLoad = new NinjaPrefabLoad();
    EffectPrefabLoad _effectPrefabLoad = new EffectPrefabLoad();

    public SoundPrefabLoad SoundPrefabLoad { get => _soundPrefabLoad; }
    public UIPrefabLoad UIPrefabLoad { get => _uiPrefabLoad; }
    public NinjaPrefabLoad NinjaPrefabLoad { get => _ninjaPrefabLoad; }
    public EffectPrefabLoad EffectPrefabLoad { get => _effectPrefabLoad; }

    public async Task LoadPrefab()
    {
        if (_soundPrefabLoad.SoundPrefab != null)
            return;
        await _soundPrefabLoad.LoadPrefab();
        await _uiPrefabLoad.LoadPrefab();
        await _ninjaPrefabLoad.LoadPrefab();
        await _effectPrefabLoad.LoadPrefab();
    }
}