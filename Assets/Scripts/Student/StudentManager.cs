using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    // 싱글턴으로 호출됨
    List<Student> _students = new List<Student>();

    // 스테이지 바뀔때마다 변경?
    EStudentType _targetStateType;

    public EStudentType TargetStateType { get => _targetStateType; }

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
}