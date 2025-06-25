using UnityEngine;
using Utils;

public class IdleStudent : MonoBehaviour, IMediatorEvent
{
    StudentManager _studentManager;

    public void Init(StudentManager studentManager)
    {
        _studentManager = studentManager;
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.StopStudent, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _studentManager.StopEvent();
    }
}