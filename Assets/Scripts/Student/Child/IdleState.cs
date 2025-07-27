using UnityEngine;
using Utils;

public class IdleState : IStudentState
{
    Student _student;
    StudentManager _studentManager;

    float _returnToGymnasticsTime = 4f;
    float _time;

    public IdleState(Student student)
    {
        _student = student;
        _studentManager = GenericSingleton<StudentManager>.Instance;
    }

    void CheckTime()
    {
        _time += Time.deltaTime;
        if (_returnToGymnasticsTime <= _time)
        {
            _student.ChangeState(EStudentType.Gymnastics);
            _time = 0f;
        }
    }

    void IStudentState.Enter()
    {
        // �ִϸ��̼� ����
        _student.ChangeAnimation("Idle");
    }

    void IStudentState.Loop()
    {
        CheckTime();
    }

    void IStudentState.Exit()
    {
        // ü���� ����
        _student.ReturnToGymnastics();
    }
}