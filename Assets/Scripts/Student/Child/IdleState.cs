using UnityEngine;

public class IdleState : MonoBehaviour, IStudentState
{
    Student _student;

    public IdleState(Student student)
    {
        _student = student;
    }

    void IStudentState.Enter()
    {
        // 애니메이션 변경
    }

    void IStudentState.Loop()
    {
    }

    void IStudentState.Exit()
    {
    }
}