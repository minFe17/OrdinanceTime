using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 중재자 패턴(Mediator Pattern)을 적용한 이벤트 관리 클래스.
/// 다양한 객체 간 직접적인 의존 없이 이벤트를 전달할 수 있도록 중재 역할을 수행.
/// </summary>
public class MediatorManager : MonoBehaviour
{
    // 이벤트 타입별로 구독 중인 이벤트 객체들을 관리하는 딕셔너리
    Dictionary<EMediatorEventType, List<IMediatorEvent>> _mediatorEvents = new Dictionary<EMediatorEventType, List<IMediatorEvent>>();

    /// <summary>
    /// 이벤트를 등록합니다. 같은 타입의 이벤트가 이미 존재하면 리스트에 추가하고, 없으면 새 리스트를 생성합니다.
    /// </summary>
    public void Register(EMediatorEventType key, IMediatorEvent value)
    {
        List<IMediatorEvent> list;

        // 해당 이벤트 타입의 리스트가 없으면 새로 생성
        if (!_mediatorEvents.TryGetValue(key, out list))
        {
            list = new List<IMediatorEvent> { value };
            _mediatorEvents[key] = list;
        }
        // 이미 리스트가 존재하면 중복 방지 후 추가
        else if (!list.Contains(value))
            list.Add(value);
    }

    /// <summary>
    /// 특정 이벤트 타입을 모든 구독자에게 전달합니다. (브로드캐스트)
    /// </summary>
    public void Notify(EMediatorEventType key, object data = null)
    {
        if (_mediatorEvents.TryGetValue(key, out List<IMediatorEvent> list))
        {
            for (int i = 0; i < list.Count; i++)
            {
                // 각 구독자에게 이벤트 데이터 전달
                list[i].HandleEvent(data); 
            }
        }
    }

    /// <summary>
    /// 모든 이벤트 구독 정보를 제거합니다.
    /// </summary>
    public void UnregisterAllEvent()
    {
        _mediatorEvents.Clear();
    }
}
