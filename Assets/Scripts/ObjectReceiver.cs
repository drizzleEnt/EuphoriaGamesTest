using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectReceiver : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType;

    private Player _player;
    private CollectableObject _collectableObject;
    private bool _canTake = false;

    public event UnityAction EnterZone;
    public event UnityAction<ObjectType> CollectedObject;

    private void Update()
    {
        if (_canTake == false)
            return;

        if (Input.GetKeyDown(KeyCode.F))
            TakeObject();
    }

    private void OnTriggerEnter(Collider other)
    {
        EnterZone?.Invoke();
        
        if (other.TryGetComponent(out Player player))
        {
            _player = player;
            _canTake = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            _player = null;
            _canTake = false;
        }
    }

    private void TakeObject()
    {
        _collectableObject = _player.GetComponentInChildren<CollectableObject>();
        
        if (_collectableObject == null)
            return;

        switch (_objectType)
        {
            case ObjectType.Cube:
                if (_player.GetComponentInChildren<Cube>())
                    Collect();
                break;
            case ObjectType.Sphere:
                if (_player.GetComponentInChildren<Sphere>())
                    Collect();
                break;
            case ObjectType.Capsul:
                if (_player.GetComponentInChildren<Capsule>())
                    Collect();
                break;
            default:
                break;
        }
    }

    private void Collect()
    {
        CollectedObject?.Invoke(_objectType);
        Debug.Log(_objectType);
        _player.GetComponent<PlayerObjectTaker>().FreeHand();
        Destroy(_collectableObject.gameObject);
    }

}

public enum ObjectType
{
    Cube,
    Sphere,
    Capsul
}
