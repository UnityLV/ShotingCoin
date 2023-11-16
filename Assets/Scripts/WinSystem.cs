using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class WinSystem : MonoBehaviour
{
    [SerializeField] private UnityEvent _onVictory;
    public DefeatSystem DefeatSystem;

    private void OnEnable()
    {
        if (Game.Instance == null)
        {
            return;
        }

        Game.Instance.LevelLoader.LevelCompleted += Win;
        
    }

    private void OnDisable()
    {
        if (Game.Instance == null)
        {
            return;
        }
        Game.Instance.LevelLoader.LevelCompleted -= Win;
    }

    public async void Win()
    {
        DefeatSystem.DisableGame();
        await Task.Delay(200);
        _onVictory.Invoke();
    }
}