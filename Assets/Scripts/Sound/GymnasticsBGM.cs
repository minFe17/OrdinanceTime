using System.Collections.Generic;
using UnityEngine;
using Utils;

public class GymnasticsBGM : MonoBehaviour
{
    [SerializeField] List<float> _timeList = new List<float>();
    [SerializeField] string _animationName = "Gymnastics";

    PigeonSFXEvent _pigeonSFXEvent = new PigeonSFXEvent();
    StopSFXEvent _stopSFXEvent = new StopSFXEvent();

    int _targetIndex;
    float _time;
    float _maxTime = 120f;
    float _pigeonTime = 35f; 
    float _ryoikiTenkaiTime = 50f;
    float _nanigaSukiTime = 80f;
    float _waflashTime = 100f;

    bool _isGymnasticsEnd;
    bool _isPigeonEventCalled;
    bool _isRyoikiTenkaiEventCalled;
    bool _isNanigaSukiEventCalled;
    bool _isWaflashEventCalled;

    private void Start()
    {
        _pigeonSFXEvent.Init();
        _stopSFXEvent.Init();
    }

    private void Update()
    {
        if (_isGymnasticsEnd)
            return;
        if (_targetIndex >= _timeList.Count)
            return;
        _time += Time.deltaTime;
        if (_timeList[_targetIndex] <= _time)
        {
            GenericSingleton<StudentManager>.Instance.ChangeAnimation(_animationName, _targetIndex + 1);
            _targetIndex++;
        }
        PigeonEvent();
        RyoikiTenkaiEvent();
        NanigaSukiTime();
        WaflashTime();

        if (_maxTime <= _time)
        {
            _isGymnasticsEnd = true;
            Invoke("Clear", 3f);
            GenericSingleton<StudentManager>.Instance.ChangeAnimation(_animationName, 0);
        }
    }

    void PigeonEvent()
    {
        if (_pigeonTime <= _time)
        {
            if (_isPigeonEventCalled)
                return;
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.PigeonEvent);
            _isPigeonEventCalled = true;
        }
    }

    void RyoikiTenkaiEvent()
    {
        if (_ryoikiTenkaiTime <= _time)
        {
            if (_isRyoikiTenkaiEventCalled)
                return;
            _isRyoikiTenkaiEventCalled = true;
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.RyoikiTenkaiEvent);
        }
    }

    void NanigaSukiTime()
    {
        if (_nanigaSukiTime <= _time)
        {
            if (_isNanigaSukiEventCalled)
                return;
            _isNanigaSukiEventCalled = true;
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.NanigaSukiEvent);
        }
    }

    void WaflashTime()
    {
        if (_waflashTime <= _time)
        {
            if (_isWaflashEventCalled)
                return;
            _isWaflashEventCalled = true;
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.WaflashEvent);
        }
    }

    void Clear()
    {
        GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.GameClear);
    }
}