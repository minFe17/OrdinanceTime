using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameClearUI : MonoBehaviour, IMediatorEvent
{
    [SerializeField] GameObject _panel;

    Animator _animator;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameClear, this);
        _animator = GetComponent<Animator>();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _panel.SetActive(true);
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.GameClear);
        GenericSingleton<MediatorManager>.Instance.UnregisterAllEvent();
        _animator.SetBool("isShowText", true);
        Invoke("LoadScene", 2f);
    }
}