using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class Pigeon : MonoBehaviour, IMediatorEvent
{
    [SerializeField] List<Image> _pigeonImage = new List<Image>();
    [SerializeField] List<Color> _colorList = new List<Color>();
    [SerializeField] float _idleTime;

    Animator _animator;
    RectTransform _pigeonRectTransform;
    Vector3 _startPos;
    Vector3 _targetPos;
    int _currentIndex = 0;
    int _randomPath;
    float _speed = 1f;
    float _elapsed;
    bool _isPigeonEvent = false;
    bool _isIdle = false;
    bool _hasIdled = false;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.PigeonEvent, this);
        _animator = GetComponent<Animator>();
        _pigeonRectTransform = GetComponent<RectTransform>();
        SetNextPosition();
    }

    void SetNextPosition()
    {
        _startPos = _pigeonRectTransform.anchoredPosition;
        _elapsed = 0f;
    }

    void Set()
    {
        _isPigeonEvent = false;
        _hasIdled = false;
        _animator.SetBool("isFly", false);
        _animator.SetBool("isIdle", false);
        int random = Random.Range(0, _colorList.Count);
        SetColor(_colorList[random]);
    }

    void SetColor(Color color)
    {
        for (int i = 0; i < _pigeonImage.Count; i++)
        {
            _pigeonImage[i].color = color;
        }
    }
  
    void Idle()
    {
        if (_animator.GetBool("isIdle"))
            return;
        if (_hasIdled)
            return;
        _animator.SetBool("isIdle", true);
        _isIdle = true;
        StartCoroutine(EndIdleRoutine());
    }

    void EndIdle()
    {
        _animator.SetBool("isFly", true);
        _isIdle = false;
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        _isPigeonEvent = true;
        for(int i=0; i<_pigeonImage.Count; i++)
            _pigeonImage[i].gameObject.SetActive(true);
        Set();
        _animator.SetBool("isMove", true);
    }

    IEnumerator EndIdleRoutine()
    {
        yield return new WaitForSeconds(_idleTime);
        EndIdle();
    }
}