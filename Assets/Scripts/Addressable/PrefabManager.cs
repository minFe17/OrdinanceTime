using System.Threading.Tasks;
using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    SoundPrefabLoad _soundPrefabLoad = new SoundPrefabLoad();

    public SoundPrefabLoad SoundPrefabLoad { get => _soundPrefabLoad; }

    public async Task LoadPrefab()
    {
        await _soundPrefabLoad.LoadPrefab();
    }
}