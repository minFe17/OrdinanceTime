using UnityEngine;
using Utils;

public class RyoikiTenkai : MonoBehaviour, IMediatorEvent
{
    [SerializeField] float _lifetime;

    Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.RyoikiTenkaiEvent, this);

        _animator.SetBool("isRyoikiTenkai", true);
        GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.StopStudent);
        Invoke("EndAnimation", _lifetime);

    }

    void EndAnimation()
    {
        _animator.SetBool("isRyoikiTenkai", false);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _animator.SetBool("isRyoikiTenkai", true);
        GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.StopStudent);
        Invoke("EndAnimation", _lifetime);
    }
}