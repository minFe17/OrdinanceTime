using UnityEngine;
using Utils;

public class PigeonSFXEvent : MonoBehaviour, IMediatorEvent
{
    public void Init()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.PigeonEvent, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.Pigeon);
    }
}