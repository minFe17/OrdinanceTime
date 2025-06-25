using UnityEngine;
using Utils;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        SetManager();
    }

    private void SetManager()
    {
        GenericSingleton<StudentManager>.Instance.Init();
        GenericSingleton<AudioClipManager>.Instance.Init();
    }
}