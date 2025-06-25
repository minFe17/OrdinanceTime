using UnityEngine;
using Utils;

public class RyoikiTenkai : MonoBehaviour, IMediatorEvent
{
    [SerializeField] float _lifetime;

    Animator _animator;
    MediatorManager _mediatorManager;

    bool _isOnEvent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mediatorManager = GenericSingleton<MediatorManager>.Instance;
        _mediatorManager.Register(EMediatorEventType.RyoikiTenkaiEvent, this);
    }

    void PlayAnimation()
    {
        _animator.speed = 0.7f;
        _animator.SetBool("isRyoikiTenkai", true);
        Invoke("EndAnimation", _lifetime + 0.7f);
    }

    void EndAnimation()
    {
        _animator.SetBool("isRyoikiTenkai", false);
        _animator.speed = 1f;
        GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.StopStudent);
    }

    void PlaySFX()
    {
        _mediatorManager.Notify(EMediatorEventType.PlayAudio, ESFXType.RyoikiTenkai);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        if(_isOnEvent)
            return;
        PlaySFX();
        Invoke("PlayAnimation", 0.7f);
        _isOnEvent = true;
    }
}