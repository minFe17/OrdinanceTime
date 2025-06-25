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
    float _pigeonTime = 45f;
    float _ryoikiTenkaiTime = 10f;

    bool _isGymnasticsEnd;
    bool _isPigeonEventCalled;
    bool _isRyoikiTenkaiEventCalled;

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

        if (_maxTime <= _time)
        {
            _isGymnasticsEnd = true;
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
            Debug.Log("Ryoiki Tenkai Event Called");
            if (_isRyoikiTenkaiEventCalled)
                return;
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.RyoikiTenkaiEvent);
            _isRyoikiTenkaiEventCalled = true;
        }
    }
}