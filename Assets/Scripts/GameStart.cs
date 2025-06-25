using System.Collections.Generic;
using UnityEngine;
using Utils;

public class GameStart : MonoBehaviour
{
    [SerializeField] List<Transform> _studentPos = new List<Transform>();
    private void Start()
    {
        SetManager();
        CreateStudent();
    }

    private void SetManager()
    {
        GenericSingleton<StudentManager>.Instance.Init();
        GenericSingleton<AudioClipManager>.Instance.Init();
        GenericSingleton<AudioClipManager>.Instance.PlayBGM(EBGMType.Gymnastics);
        Instantiate(GenericSingleton<PrefabManager>.Instance.UIPrefabLoad.UIPrefab);

    }

    void CreateStudent()
    {
        for (int i = 0; i < _studentPos.Count; i++)
        {
            GameObject temp = Instantiate(GenericSingleton<PrefabManager>.Instance.NinjaPrefabLoad.NinjaPrefab);
            temp.transform.position = _studentPos[i].position;
        }
    }
}