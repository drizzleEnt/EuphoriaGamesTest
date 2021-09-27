using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectTaker : MonoBehaviour
{
    [SerializeField] private LayerMask _objectLayer;
    [SerializeField] private Transform _conteiner;

    private Camera _camera;
    private float _distance = 10f;
    private bool _canTake = true;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canTake)
            TakeObject();
    }

    private void TakeObject()
    {
        Vector3 forward = _camera.transform.TransformDirection(Vector3.forward);

        RaycastHit hit;

        if (Physics.Raycast(_camera.transform.position, forward, out hit, _distance, _objectLayer))
        {

            GameObject interactableObject = hit.collider.gameObject;

            interactableObject.GetComponent<Rigidbody>().isKinematic = true;

            interactableObject.transform.parent = _conteiner;
            interactableObject.transform.localPosition = Vector3.zero;
            interactableObject.transform.localEulerAngles = Vector3.zero;
            interactableObject.transform.localScale = new Vector3(0.5f,0.5f,0.5f);

            _canTake = false;
        }
    }

    public void FreeHand()
    {
        _canTake = true;
    }
}
