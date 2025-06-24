using UnityEngine;
using Utils;

public class Hp : MonoBehaviour, IMediatorEvent
{
    int _hp = 3;

    public void Init()
    {
        GenericSingleton<MediatorManager>.Instance.Register(EMediatorEventType.ChangeHP, this);
    }

    void IMediatorEvent.HandleEvent(object data)
    {
        int value = (int)data;
        _hp += value;
        Debug.Log($"HP 감소: {_hp}");
        if (_hp <= 0)
        {
            // 게임오버
        }
    }
}