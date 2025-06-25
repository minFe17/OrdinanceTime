using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    // 싱글턴으로 호출됨
    List<Student> _students = new List<Student>();
    IdleStudent _idleStudent = new IdleStudent();
    StopStudent _stopStudent = new StopStudent();
    NanigaSukiEvent _nanigaSukiEvent = new NanigaSukiEvent();
    WafalseEvent _wafalseEvent = new WafalseEvent();

    // 스테이지 바뀔때마다 변경?
    EStudentType _targetStateType;

    int _animationHash;
    float _animationTime;
    float _time;
    float _botherTime = 5f;

    public EStudentType TargetStateType { get => _targetStateType; }

    private void Update()
    {
        CheckTime();
    }

    public void Init()
    {
        _idleStudent.Init(this);
        _stopStudent.Init(this);
        _nanigaSukiEvent.init(this);
        _wafalseEvent.init(this);
    }

    void CheckTime()
    {
        _time += Time.deltaTime;
        if (_botherTime <= _time)
        {
            int index = Random.Range(1, _students.Count);
            _students[index].ChangeState(EStudentType.Idle);
            _time = 0f;
        }
    }

    public void AddStudent(Student student)
    {
        _students.Add(student);
    }

    public float GetCurrentAnimationTime()
    {
        return _students[0].GetAnimationTime();
    }

    public int GetCurrentAnimationHash()
    {
        return _students[0].GetAnimationHash();

    }

    public void SetTargetStateType(EStudentType targetStateType)
    {
        _targetStateType = targetStateType;
    }

    public void ChangeStateStudents(EStudentType type)
    {
        _targetStateType = type;
        for (int i = 0; i < _students.Count; i++)
        {
            _students[i].ChangeState(_targetStateType);
        }
    }

    public void ChangeAnimation(string name, int value)
    {
        for (int i = 0; i < _students.Count; i++)
            _students[i].ChangeAnimation(name, value);
    }

    public void StopEvent()
    {
        _targetStateType = EStudentType.Stop;
        _stopStudent.OnStop();
        int random = Random.Range(1, 5);

        int count = _students.Count - random;
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(1, _students.Count);
            while (_students[index].CurrentType == EStudentType.Stop)
                index = Random.Range(1, _students.Count);
            _students[index].ChangeState(EStudentType.Stop);
        }
        _students[0].ChangeState(EStudentType.Stop);
        
        _animationHash = GetCurrentAnimationHash();
        _animationTime = GetCurrentAnimationTime();

        Invoke("EnndStopEvent", 3f);
    }

    public void EndStopEvent()
    {
        _targetStateType = EStudentType.Gymnastics;
        for (int i = 0; i < _students.Count; i++)
        {
            if (_students[i].CurrentType == EStudentType.Gymnastics)
                _students[i].ReturnToGymnastics(_animationHash, _animationTime);
            else if (_students[i].CurrentType != EStudentType.Gymnastics)
                _students[i].ChangeState(EStudentType.Gymnastics);
        }
    }

    public void NanigaSukiEvent()
    {
        int random = Random.Range(1, 4);

        int count = _students.Count - random;
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(1, _students.Count);
            while (_students[index].CurrentType == EStudentType.NanigaSuki)
                index = Random.Range(1, _students.Count);
            _students[index].ChangeState(EStudentType.NanigaSuki);
        }
        Invoke("EnndStopEvent", 3f);
    }

    public void WaflashEvent()
    {
        int random = Random.Range(1, 4);

        int count = _students.Count - random;
        for (int i = 0; i < count; i++)
        {
            int index = Random.Range(1, _students.Count);
            while (_students[index].CurrentType == EStudentType.Waflash)
                index = Random.Range(1, _students.Count);
            _students[index].ChangeState(EStudentType.Waflash);
        }
    }
}