using System;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class LevelLoader
{
    public event Action LevelCompleted;
    public event Action StartLevelLoad;
    private LevelSettings _currentsSettings;
    public async void LoadLevel(LevelSettings settings)
    {
        _currentsSettings = settings;
        StartLevelLoad?.Invoke();
        await Task.Delay(300);
        Game.Instance.LevelGoal.Reset();
        Game.Instance.LevelGoal.SetGoal(settings.Goal, LevelComplete);
        SceneManager.LoadScene("Game");
    }

    private void LevelComplete()
    {
        UnityEngine.PlayerPrefs.SetInt($"{_currentsSettings?.Level}", 1);
        LevelCompleted?.Invoke();
    }
}