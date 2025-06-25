using UnityEngine;
using Utils;

public class GameStart : MonoBehaviour
{
    private async void Start()
    {
        await GenericSingleton<PrefabManager>.Instance.LoadPrefab();
        SetManager();
    }

    private void SetManager()
    {
        GenericSingleton<StudentManager>.Instance.Init();
        GenericSingleton<AudioClipManager>.Instance.Init();
    }
}