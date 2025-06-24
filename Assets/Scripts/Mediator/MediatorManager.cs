using System.Collections.Generic;
using UnityEngine;

public class MediatorManager : MonoBehaviour
{
    // ΩÃ±€≈œ¿∏∑Œ »£√‚µ 
    Dictionary<EMediatorEventType, List<IMediatorEvent>> _mediatorEvents = new Dictionary<EMediatorEventType, List<IMediatorEvent>>();

    public void Register(EMediatorEventType key, IMediatorEvent value)
    {
        List<IMediatorEvent> list;

        if (!_mediatorEvents.TryGetValue(key, out list))
        {
            list = new List<IMediatorEvent> { value };
            _mediatorEvents[key] = list;
        }
        else if (!list.Contains(value))
            list.Add(value);
    }

    public void Notify(EMediatorEventType key, object data = null)
    {
        if (_mediatorEvents.TryGetValue(key, out List<IMediatorEvent> list))
        {
            Debug.Log($"Notify: {key}, {list.Count}");
            for (int i = 0; i < list.Count; i++)
                list[i].HandleEvent(data);
        }
    }
}