public class GymnasticsState : IStudentState
{
    Student _student;

    public GymnasticsState(Student student)
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
        // �ִϸ��̼� ����
    }
}