using UnityEngine;
using UnityEngine.U2D;
using Utils;

public class Lobby : MonoBehaviour
{
    Animator _animator;
    [SerializeField] SpriteAtlas _spriteAtlas;

    async void Start()
    {
        await GenericSingleton<PrefabManager>.Instance.LoadPrefab();
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("doShowUI");
    }
}