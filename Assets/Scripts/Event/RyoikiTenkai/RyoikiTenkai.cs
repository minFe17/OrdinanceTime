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

        _animator.speed = 0.7f;
        _animator.SetBool("isRyoikiTenkai", true);
        Invoke("EndAnimation", _lifetime);

    }

    void EndAnimation()
    {
        _animator.SetBool("isRyoikiTenkai", false);
        _animator.speed = 1f;
        GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.StopStudent);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _animator.speed = 0.7f;
        _animator.SetBool("isRyoikiTenkai", true);
        Invoke("EndAnimation", _lifetime);
    }
}