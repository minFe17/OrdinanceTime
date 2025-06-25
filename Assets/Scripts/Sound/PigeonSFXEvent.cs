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
        int random = Random.Range((int)ESFXType.Pigeon1, (int)ESFXType.Pigeon2+1);
        GenericSingleton<AudioClipManager>.Instance.PlaySFX((ESFXType)random);
    }
}