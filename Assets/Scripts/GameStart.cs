using UnityEngine;
using Utils;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        SetManager();
    }

    private void SetManager()
    {
        GenericSingleton<StudentManager>.Instance.Init();
    }
}