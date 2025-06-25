using System.Collections;
using UnityEngine;
using Utils;

public class WafalseEvent : MonoBehaviour, IMediatorEvent
{
    StudentManager _studentManager;

    public void init(StudentManager studentManager)
    {
        _studentManager = studentManager;
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.WaflashEvent, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        Debug.Log(1);
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.Waflash);
        _studentManager.WaflashEvent();
    }
}