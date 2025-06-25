using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameOverUI : MonoBehaviour, IMediatorEvent
{
    [SerializeField] GameObject _gameOverUI;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameOver, this);
    }

    public void OnClickScreent()
    {
        SceneManager.LoadScene("LobbyScene");
    }
  
    void IMediatorEvent.HandleEvent(object data)
    {
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.GameOver);
        _gameOverUI.SetActive(true);
    }
}