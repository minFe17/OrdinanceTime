using UnityEngine;
using Utils;

public class GameOverSound : MonoBehaviour, IMediatorEvent
{
    SoundController _soundController;

    public void Init(SoundController soundController)
    {
        _soundController = soundController;
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameOver, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _soundController.GameOverSound();
    }
}