using UnityEngine;
using Utils;

public class Lobby : MonoBehaviour
{
    Animator _animator;

    async void Start()
    {
        await GenericSingleton<PrefabManager>.Instance.LoadPrefab();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("doShowButton");
    }
}