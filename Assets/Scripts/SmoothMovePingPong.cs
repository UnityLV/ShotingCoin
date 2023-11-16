using System;
using UnityEngine;

public class SmoothMovePingPong : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Vector2 _point1;
    [SerializeField] private Vector2 _point2;

    private Vector3 _position1;
    private Vector3 _position2;
    private Vector3 _targetPosition;
    private void Start()
    {
        _position1 = transform.position + (Vector3)_point1;
        _position2 = transform.position + (Vector3)_point2;
        _targetPosition = _position1;
    }

    private void Update()
    {
        if (transform.position == _position1)
        {
            _targetPosition = _position2;
        }
        else if (transform.position == _position2)
        {
            _targetPosition = _position1;
        }
        
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, Time.deltaTime * _speed);
    }
}