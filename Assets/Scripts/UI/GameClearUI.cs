using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

public class GameClearUI : MonoBehaviour, IMediatorEvent
{
    [SerializeField] GameObject _panel;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameClear, this);
    }

    public void OnClickScreent()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _panel.SetActive(true);
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.GameClear);
        Invoke("OnClickScreent", 2f);
    }
}
