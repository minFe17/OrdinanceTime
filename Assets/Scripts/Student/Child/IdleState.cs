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
        // �ִϸ��̼� ����
    }

    void IStudentState.Loop()
    {
    }

    void IStudentState.Exit()
    {
    }
}