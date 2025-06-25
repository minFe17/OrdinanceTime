using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Hp : MonoBehaviour, IMediatorEvent
{
    [SerializeField] List<GameObject> _HpImageList = new List<GameObject>();
    int _hp;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.ChangeHP, this);
        _hp = _HpImageList.Count; 
    }

    void ShowHp()
    {
        for (int i = 0; i < _HpImageList.Count; i++)
            _HpImageList[i].SetActive(false);
        for (int i = 0; i < _hp; i++)
            _HpImageList[i].SetActive(true);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        int value = (int)data;
        _hp += value;
        ShowHp();
        if (_hp <= 0)
        {
            // 게임오버
        }
    }
}