using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DefeatTimer : MonoBehaviour
{
    [SerializeField] private UnityEvent<string> _timeUpdated;
    [SerializeField] private DefeatSystem _defeatSystem;
    private int _time;

    private void Start()
    {
        SetTime();
        StartTimer();
    }

    private void SetTime()
    {
        if (Game.Instance == null )
        {
            _time = 200;
            return;
        }
        _time = (Game.Instance.LevelGoal.Goal / 2) + 20;
    }

    private void StartTimer()
    {
        StartCoroutine(Countdown());
    }

    private void UpdateText()
    {
        _timeUpdated?.Invoke(_time.ToString());
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(4);
        while (_time >= 0)
        {
            UpdateText();
            yield return new WaitForSeconds(1);
            _time--;
        }

        Defeat();
    }

    private void Defeat()
    {
        _defeatSystem.Defeat();
    }
}