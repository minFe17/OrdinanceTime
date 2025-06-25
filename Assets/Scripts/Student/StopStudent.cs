using System.Threading.Tasks;
using UnityEngine;

public class StopStudent : MonoBehaviour
{
    StudentManager _studentManager;

    int _stopTime = 5;

    public void Init(StudentManager studentManager)
    {
        _studentManager = studentManager;
    }

    public async void OnStop()
    {
        await Task.Delay(_stopTime * 1000);
        OnResume();
    }

    public void OnResume()
    {
        _studentManager.ChangeStateStudents(EStudentType.Gymnastics);
    }
}