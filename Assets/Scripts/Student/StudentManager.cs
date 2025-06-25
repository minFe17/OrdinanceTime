using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    // 싱글턴으로 호출됨
    List<Student> _students = new List<Student>();
    IdleStudent _idleStudent = new IdleStudent();

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

    public void ChangeAnimation(string name, int value)
    {
        for (int i=0; i<_students.Count; i++)
            _students[i].ChangeAnimation(name, value);
    }

    public void StopEvent()
    {
        // BGM 정지, 볼륨 조절은 RyoikiTenkaiEvent에서 처리
        int random = Random.Range(1, 5);

        for (int i = 0; i < random; i++)
        {
            int index = Random.Range(1, _students.Count);
            while (_students[index].CurrentType == EStudentType.Stop)
                index = Random.Range(1, _students.Count);
            _students[index].ChangeState(EStudentType.Stop);
        }

        _targetStateType = EStudentType.Idle;
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
            else if (_students[i].CurrentType == EStudentType.Idle)
                _students[i].ChangeState(EStudentType.Gymnastics);
        }
    }
}