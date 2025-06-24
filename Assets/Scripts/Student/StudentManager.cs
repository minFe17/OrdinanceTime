using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    // 싱글턴으로 호출됨
    List<Student> _students = new List<Student>();
    IdleStudent _idleStudent = new IdleStudent();

    // 스테이지 바뀔때마다 변경?
    EStudentType _targetStateType;

    public EStudentType TargetStateType { get => _targetStateType; }

    public void Init()
    {
        _idleStudent.Init(this);
    }

    public float GetCurrentAnimationTime()
    {
        for(int i=0; i< _students.Count; i++)
        {
            if(_students[i].CurrentType == _targetStateType)
                return _students[i].GetAnimationTime();
        }
        return 0f; 
    }

    public void SetTargetStateType(EStudentType targetStateType)
    {
        _targetStateType = targetStateType;
    }

    public void StopEvent()
    {
        // 체조 정지
        // BGM 정지
        // 볼륨은 RyoikiTenkaiEvent이벤트에서 조절
        // 학생들 정지(몇명만 움직임) -> 움직인 학생들 클릭하면 점수 획득
        _targetStateType = EStudentType.Idle;
        // 몇초뒤에 다시 체조로
    }
}