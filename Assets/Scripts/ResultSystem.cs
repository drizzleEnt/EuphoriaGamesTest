using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ResultSystem : MonoBehaviour
{
    private List<CollectableObject> _collectableObjects = new List<CollectableObject>();

    public event UnityAction OnGameEnd;

    private void Start()
    {
        _collectableObjects = FindObjectsOfType<CollectableObject>().ToList();
        foreach (var collectableObject in _collectableObjects)
        {
            collectableObject.OnCollecting += DeleteObject;
        }
    }

    private void DeleteObject(CollectableObject collectableObject)
    {
        collectableObject.OnCollecting -= DeleteObject;
        _collectableObjects.Remove(collectableObject);
        if(_collectableObjects.Count == 0)
        {
            OnGameEnd?.Invoke();
        }
    }
}
