using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    // ΩÃ±€≈œ¿∏∑Œ »£√‚µ 
    Dictionary<EObjectType, Queue<GameObject>> _objectPool = new Dictionary<EObjectType, Queue<GameObject>>();

    public GameObject PushSlime(EObjectType type, GameObject prefab)
    {
        Queue<GameObject> slimeQueues;
        GameObject temp = null;

        _objectPool.TryGetValue(type, out slimeQueues);
        if (slimeQueues.Count > 0)
            temp = slimeQueues.Dequeue();
        else
            temp = CreateObject(prefab);
        return temp;
    }

    public void PullSlime(GameObject pullObject, EObjectType type)
    {
        Queue<GameObject> slimeQueues;
        _objectPool.TryGetValue(type, out slimeQueues);
        pullObject.SetActive(false);
        slimeQueues.Enqueue(pullObject);
        pullObject.transform.parent = this.transform;
    }

    public GameObject CreateObject(GameObject prefab)
    {
        return Instantiate(prefab);
    }
}