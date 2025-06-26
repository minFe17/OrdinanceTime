using UnityEngine;
using Utils;

public class GameOverStudent : MonoBehaviour, IMediatorEvent
{
    StudentManager _studentManager;

    public void Init(StudentManager studentManager)
    {
        _studentManager = studentManager;
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameOver, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _studentManager.Clear();
    }
}