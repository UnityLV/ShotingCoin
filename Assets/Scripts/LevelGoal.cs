using System;
using UnityEngine;
using UnityEngine.Events;

public class LevelGoal
{
    private Action _reachCallback;
    public int Goal { get; private set; }
    public int Points { get; private set; }
    private bool IsGoadReached => Points >= Goal;
    public void AddPoints(int points)
    {
        if (IsGoadReached) return;
        Points += points;
        Points = Mathf.Clamp(Points, 0, Goal);
        TryCompleteGoal();
    }
    
    public void Reset()
    {
        Points = 0;
    }

    private void TryCompleteGoal()
    {
        if (IsGoadReached)
        {
            _reachCallback?.Invoke();
        }
    }

    

    public void SetGoal(int goal, Action reachCallback)
    {
        Goal = goal;
        _reachCallback = reachCallback;
    }
}