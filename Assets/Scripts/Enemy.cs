using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;
using UnityEngine.Serialization;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explodeOfWallEffect;

    public void ExplodeOfWall()
    {
        var effect = Instantiate(_explodeOfWallEffect, transform.position + Vector3.back, Quaternion.identity);
        Destroy(effect, 4);
    }

    public void SwitchToPlayerAttack()
    {
        GetComponentInChildren<Rigidbody2D>().gravityScale = 0.4f;
    }
}