using UnityEngine;
using Utils;

public class SoundManager : MonoBehaviour
{
    // ΩÃ±€≈œ¿∏∑Œ »£√‚µ 
    SoundController _soundController;
    PrefabManager _prefabManager;

    public SoundController SoundController
    {
        get
        {
            if (_soundController == null)
            {
                if (_prefabManager == null)
                    _prefabManager = GenericSingleton<PrefabManager>.Instance;
                GameObject soundController = Instantiate(_prefabManager.SoundPrefabLoad.SoundPrefab);
                _soundController = soundController.GetComponent<SoundController>();
            }
            return _soundController;
        }
    }
}