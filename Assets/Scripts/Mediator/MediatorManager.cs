using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������ ����(Mediator Pattern)�� ������ �̺�Ʈ ���� Ŭ����.
/// �پ��� ��ü �� �������� ���� ���� �̺�Ʈ�� ������ �� �ֵ��� ���� ������ ����.
/// </summary>
public class MediatorManager : MonoBehaviour
{
    // �̺�Ʈ Ÿ�Ժ��� ���� ���� �̺�Ʈ ��ü���� �����ϴ� ��ųʸ�
    Dictionary<EMediatorEventType, List<IMediatorEvent>> _mediatorEvents = new Dictionary<EMediatorEventType, List<IMediatorEvent>>();

    /// <summary>
    /// �̺�Ʈ�� ����մϴ�. ���� Ÿ���� �̺�Ʈ�� �̹� �����ϸ� ����Ʈ�� �߰��ϰ�, ������ �� ����Ʈ�� �����մϴ�.
    /// </summary>
    public void Register(EMediatorEventType key, IMediatorEvent value)
    {
        List<IMediatorEvent> list;

        // �ش� �̺�Ʈ Ÿ���� ����Ʈ�� ������ ���� ����
        if (!_mediatorEvents.TryGetValue(key, out list))
        {
            list = new List<IMediatorEvent> { value };
            _mediatorEvents[key] = list;
        }
        // �̹� ����Ʈ�� �����ϸ� �ߺ� ���� �� �߰�
        else if (!list.Contains(value))
            list.Add(value);
    }

    /// <summary>
    /// Ư�� �̺�Ʈ Ÿ���� ��� �����ڿ��� �����մϴ�. (��ε�ĳ��Ʈ)
    /// </summary>
    public void Notify(EMediatorEventType key, object data = null)
    {
        if (_mediatorEvents.TryGetValue(key, out List<IMediatorEvent> list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                // �� �����ڿ��� �̺�Ʈ ������ ����
                list[i].HandleEvent(data); 
            }
        }
    }

    /// <summary>
    /// ��� �̺�Ʈ ���� ������ �����մϴ�.
    /// </summary>
    public void UnregisterAllEvent()
    {
        _mediatorEvents.Clear();
    }
}
