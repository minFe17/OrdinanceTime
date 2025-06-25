using System.Threading.Tasks;
using UnityEngine;

public class NinjaPrefabLoad : PrefabLoadBase
{
    GameObject _ninjaPrefab;

    public GameObject NinjaPrefab { get => _ninjaPrefab; }

    public override async Task LoadPrefab()
    {
        Init();
        _ninjaPrefab = await _addressableManager.GetAddressableAsset<GameObject>("Ninja");
    }
}