using UnityEngine;
using UnityEngine.Events;

public class OnLevelComplete : MonoBehaviour
{
    [SerializeField] private UnityEvent _onVictory;

    private void OnEnable()
    {
        Game.Instance.LevelLoader.LevelCompleted += Win;
    }

    private void OnDisable()
    {
        Game.Instance.LevelLoader.LevelCompleted -= Win;
    }

    private void Win()
    {
        _onVictory?.Invoke();
    }
}