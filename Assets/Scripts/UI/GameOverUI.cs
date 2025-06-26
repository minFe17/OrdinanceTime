using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameOverUI : MonoBehaviour, IMediatorEvent
{
    [SerializeField] GameObject _gameOverUI;

    Animator _animator;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameOver, this);
        _animator = GetComponent<Animator>();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
  
    void IMediatorEvent.HandleEvent(object data)
    {
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.GameOver);
        _gameOverUI.SetActive(true);
        _animator.SetBool("isShowText", true);
        GenericSingleton<MediatorManager>.Instance.UnregisterAllEvent();
        Invoke("LoadScene", 2f);
    }
}