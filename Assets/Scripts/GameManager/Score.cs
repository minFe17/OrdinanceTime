using UnityEngine;
using Utils;

public class Score : MonoBehaviour, IMediatorEvent
{
    MediatorManager _mediatorManager;

    int _score;
    int _ryoikiTenkaiScore = 100;

    public void Init()
    {
        _mediatorManager = GenericSingleton<MediatorManager>.Instance;
        _mediatorManager.Register(EMediatorEventType.AddScore, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _score += (int)(object)data;
        if (_score <= _ryoikiTenkaiScore)
            _mediatorManager.Notify(EMediatorEventType.RyoikiTenkaiEvent);
    }
}