using UnityEngine;

public class GymnasticsType : IStudentState
{
    Student _student;

    public GymnasticsType(Student student)
    {
        _student= student;  
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
        throw new System.NotImplementedException();
        // �ִϸ��̼� ����
    }
}