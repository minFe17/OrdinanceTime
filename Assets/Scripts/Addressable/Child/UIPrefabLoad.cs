using System.Threading.Tasks;
using UnityEngine;

public class UIPrefabLoad : PrefabLoadBase
{
    GameObject _uiPrefab;

    public GameObject UIPrefab { get => _uiPrefab; }

    public override async Task LoadPrefab()
    {
        Init();
        _uiPrefab = await _addressableManager.GetAddressableAsset<GameObject>("UI");
    }
}