public class GymnasticsState : IStudentState
{
    Student _student;

    public GymnasticsState(Student student)
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
        // 애니메이션 변경
    }
}