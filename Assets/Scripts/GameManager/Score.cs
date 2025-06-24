using UnityEngine;
using Utils;

public class Score : MonoBehaviour, IMediatorEvent
{
    int _score;

    public void Init()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.AddScore, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _score += (int)(object)data;
    }
}