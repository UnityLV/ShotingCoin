using System;
using UnityEngine;

public class ToEdgeStick : MonoBehaviour
{
    [SerializeField] private Vector2 _position;

    private void Awake()
    {
        float halfHeight = Camera.main.orthographicSize;
        float halfWidth = halfHeight * Camera.main.aspect;

        Vector2 position = new Vector2 { x = _position.x * halfWidth, y = _position.y * halfHeight };

        transform.position = Camera.main.transform.TransformPoint(position);
        transform.position = new Vector3 { x = transform.position.x, y = transform.position.y, z = 0 };
    }
}