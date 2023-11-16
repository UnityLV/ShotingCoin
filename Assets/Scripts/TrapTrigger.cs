using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private DefeatSystem _defeatSystem;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.TryGetComponent(out Trap trap))
        {
            trap.ExplodeOfWall();
            Trigger();
            Destroy(other.gameObject);
        }
    }

    private void Trigger()
    {
        _defeatSystem.Defeat(600);
    }
}