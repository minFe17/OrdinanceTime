using System.Threading.Tasks;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    SoundPrefabLoad _soundPrefabLoad = new SoundPrefabLoad();
    UIPrefabLoad _uiPrefabLoad = new UIPrefabLoad();
    NinjaPrefabLoad _ninjaPrefabLoad = new NinjaPrefabLoad();

    public SoundPrefabLoad SoundPrefabLoad { get => _soundPrefabLoad; }
    public UIPrefabLoad UIPrefabLoad { get => _uiPrefabLoad; }
    public NinjaPrefabLoad NinjaPrefabLoad { get => _ninjaPrefabLoad; }

    public async Task LoadPrefab()
    {
        await _soundPrefabLoad.LoadPrefab();
        await _uiPrefabLoad.LoadPrefab();
        await _ninjaPrefabLoad.LoadPrefab();
    }
}