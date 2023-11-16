using UnityEngine;
using UnityEngine.Events;

public class UnityEventBooleanUnpacker : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTrue;
    [SerializeField] private UnityEvent _onFalse;

    public void OnChanged(bool value)
    {
        if (value)
        {
            _onTrue.Invoke();
        }
        else
        {
            _onFalse.Invoke();
        }
    }
}