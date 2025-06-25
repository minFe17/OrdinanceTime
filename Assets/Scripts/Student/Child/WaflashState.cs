using UnityEngine;
using Utils;

public class WaflashState : MonoBehaviour, IStudentState
{
    Student _student;
    StudentManager _studentManager;

    float _time;
    float _returnTime = 2f;

    public WaflashState(Student student)
    {
        _student = student;
        _studentManager = GenericSingleton<StudentManager>.Instance;
    }

    void ReturnToGymnasticsState()
    {
        _student.ReturnToGymnastics(_studentManager.GetCurrentAnimationHash(), _studentManager.GetCurrentAnimationTime());
    }

    void IStudentState.Enter()
    {
        _student.ChangeAnimationTrigger("doWaflash");
        ReturnToGymnasticsState();
    }

    void IStudentState.Exit()
    {
        _student.ReturnToGymnastics(_studentManager.GetCurrentAnimationHash(), _studentManager.GetCurrentAnimationTime());
    }

    void IStudentState.Loop()
    {
        _time += Time.deltaTime;
        if (_time >= _returnTime)
        {
            _student.ChangeState(EStudentType.Gymnastics);
            _student.ReturnToGymnastics(_studentManager.GetCurrentAnimationHash(), _studentManager.GetCurrentAnimationTime());
            _time = 0f;
        }
    }
}
