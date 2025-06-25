using UnityEngine;
using Utils;

public class NanigaSukiEvent : MonoBehaviour, IMediatorEvent
{
    StudentManager _studentManager;

    public void init(StudentManager studentManager)
    {
        _studentManager = studentManager;
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.NanigaSukiEvent, this);  
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.NanigaSuki);
        _studentManager.NanigaSukiEvent();
    }
}