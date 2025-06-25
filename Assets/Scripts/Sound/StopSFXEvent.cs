using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class StopSFXEvent : MonoBehaviour, IMediatorEvent
{
    public void Init()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.StopSFX, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        GenericSingleton<AudioClipManager>.Instance.StopSFX();
    }
}