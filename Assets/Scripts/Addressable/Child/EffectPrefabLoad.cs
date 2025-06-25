using System.Threading.Tasks;
using UnityEngine;

public class EffectPrefabLoad : PrefabLoadBase
{
    GameObject _effectPrefab;

    public GameObject EffectPrefab { get => _effectPrefab; }

    public override async Task LoadPrefab()
    {
        Init();
        _effectPrefab = await _addressableManager.GetAddressableAsset<GameObject>("Effect");
    }
}