using UnityEngine;
using Utils;

public class IdleState : MonoBehaviour, IStudentState
{
    Student _student;
    StudentManager _studentManager;

    float _returnToGymnasticsTime = 1f;
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
        // 애니메이션 변경
        _student.ChangeAnimationSpeed(0.5f);
    }

    void IStudentState.Loop()
    {
        CheckTime();
    }

    void IStudentState.Exit()
    {
        _student.ChangeAnimationSpeed(1f);
        _student.ReturnToGymnastics(_studentManager.GetCurrentAnimationHash(), _studentManager.GetCurrentAnimationTime());
    }
}