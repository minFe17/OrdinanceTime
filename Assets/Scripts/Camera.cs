using UnityEngine;
using Utils;

public class Camera : MonoBehaviour, IMediatorEvent
{
    Animator _animator;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.ChangeHP, this);
        _animator = GetComponent<Animator>();
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _animator.SetTrigger("doFail");
    }
}