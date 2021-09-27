using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollectableObject : MonoBehaviour
{
    public event UnityAction<CollectableObject> OnCollecting;

    private void OnDestroy()
    {
        OnCollecting?.Invoke(this);
    }
}
