using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Pigeon : MonoBehaviour, IMediatorEvent
{
    [SerializeField] List<PigeonFlyPos> _flyPosList = new List<PigeonFlyPos>();
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
        _randomPath = Random.Range(0, _flyPosList.Count);
        _pigeonRectTransform.anchoredPosition = _flyPosList[_randomPath].PositionList[0].anchoredPosition;
        SetNextPosition();
    }

    void Update()
    {
        Move();
    }

    void SetNextPosition()
    {
        _currentIndex = (_currentIndex + 1) % _flyPosList[_randomPath].PositionList.Count;
        _startPos = _pigeonRectTransform.anchoredPosition;
        _targetPos = _flyPosList[_randomPath].PositionList[_currentIndex].anchoredPosition;
        _elapsed = 0f;
    }

    void Set()
    {
        _isPigeonEvent = false;
        _hasIdled = false;
        _animator.SetBool("isFly", false);
        _animator.SetBool("isIdle", false);
    }

    void Move()
    {
        if (!_isPigeonEvent || _isIdle)
            return;
        _elapsed += Time.deltaTime;
        float t = Mathf.Clamp01(_elapsed / _speed);
        _pigeonRectTransform.anchoredPosition = Vector3.Lerp(_startPos, _targetPos, t);

        if (t >= 1f)
            SetNextPosition();

        if (_currentIndex == 0)
        {
            Set();

        }
        else if (_currentIndex == (_flyPosList[_randomPath].PositionList.Count / 2) + 1)
        {
            Idle();
            _hasIdled = true;
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
    }

    IEnumerator EndIdleRoutine()
    {
        yield return new WaitForSeconds(_idleTime);
        EndIdle();
    }
}