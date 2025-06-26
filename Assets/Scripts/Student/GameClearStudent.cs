using UnityEngine;
using Utils;

public class GameClearStudent : MonoBehaviour, IMediatorEvent
{
    StudentManager _studentManager;

    public void Init(StudentManager studentManager)
    {
        _studentManager = studentManager;
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.GameClear, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _studentManager.Clear();
    }
}