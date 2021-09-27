using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float _xMaxRotate;
    [SerializeField] private float _yMaxRotate;

    private Vector2 _lookDirection;
    private Vector3 _rotate;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _rotate = transform.rotation.eulerAngles;
    }

    private void Update()
    {
        _lookDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        Rotate(_lookDirection);
    }

    private void Rotate(Vector2 lookDirection)
    {
        

        _rotate.x -= -lookDirection.x;

        _rotate.y -= lookDirection.y;
        _rotate.y = Mathf.Clamp(_rotate.y, -_yMaxRotate, _yMaxRotate);

        transform.localEulerAngles = new Vector3(0, _rotate.x, 0);
        _camera.transform.localEulerAngles = new Vector3(_rotate.y, 0, 0);
    }
}
