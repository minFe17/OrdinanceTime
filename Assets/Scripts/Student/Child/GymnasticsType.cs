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
        // 애니메이션 변경
    }

    void IStudentState.Loop()
    {

    }

    void IStudentState.Exit()
    {
        throw new System.NotImplementedException();
        // 애니메이션 변경
    }
}