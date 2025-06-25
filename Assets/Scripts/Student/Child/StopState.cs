using UnityEngine;

public class StopState : MonoBehaviour, IStudentState
{
    Student _student;

    public StopState(Student student)
    {
        _student = student;
    }

    void IStudentState.Enter()
    {
        _student.ChangeAnimationSpeed(0f);
    }

    void IStudentState.Loop()
    {

    }

    void IStudentState.Exit()
    {
        _student.ChangeAnimationSpeed(1f);
    }
}