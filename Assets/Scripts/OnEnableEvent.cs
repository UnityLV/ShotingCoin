using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
    public UnityEvent Enable;

    private void OnEnable()
    {
        Enable.Invoke();
    }
}