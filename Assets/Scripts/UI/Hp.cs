using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Hp : MonoBehaviour, IMediatorEvent
{
    [SerializeField] List<GameObject> _hpImageList = new List<GameObject>();

    int _hp;

    void Start()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.ChangeHP, this);
        _hp = _hpImageList.Count;
    }

    void ShowHp(int value)
    {
        if (_hp < 0)
            return;
        if (value < 0)
            _hpImageList[_hp].SetActive(false);
        else if (value > 0)
            _hpImageList[_hp - 1].SetActive(true);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        int value = (int)data;
        _hp += value;
        ShowHp(value);
        GenericSingleton<AudioClipManager>.Instance.PlaySFX(ESFXType.Fail);
        if (_hp <= 0)
            GenericSingleton<MediatorManager>.Instance.Notify(EMediatorEventType.GameOver, this);
    }
}