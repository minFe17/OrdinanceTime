using UnityEngine;
using Utils;

public class Lobby : MonoBehaviour
{
    [SerializeField] GameObject _prologObject;
    Animator _animator;

    async void Start()
    {
        _animator = GetComponent<Animator>();
        if (!GenericSingleton<PrefabManager>.Instance.LoadPrefabDone())
        {
            _prologObject.SetActive(true);
            _animator.SetBool("isProlog", true);
            await GenericSingleton<PrefabManager>.Instance.LoadPrefab();
            Invoke("ShowUI", 5f);
        }
        else
        {
            ShowUI();
        }
    }

    void ShowUI()
    {
        if(_prologObject.activeSelf)
        {
            _prologObject.SetActive(false);
        }
        _animator.SetBool("isShowUI", true);
    }
}