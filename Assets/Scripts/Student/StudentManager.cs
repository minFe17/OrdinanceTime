using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour
{
    // �̱������� ȣ���
    List<Student> _students = new List<Student>();

    // �������� �ٲ𶧸��� ����?
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