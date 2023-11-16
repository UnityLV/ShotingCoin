﻿using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointDetector : MonoBehaviour
{
    [SerializeField] private AddPoints _addPointsPrefab;
    [SerializeField] private TMP_Text[] _counterTexts;
    [SerializeField] private int _points;
    public DefeatSystem DefeatSystem;
    public int Points => Game.Instance.LevelGoal.Points;

    private void Start()
    {
        if (Game.Instance != null)
        {
            Game.Instance.LevelGoal.Reset();
        }

        UpdatePointsCounters();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (Game.Instance != null)
            {
                Game.Instance.LevelGoal.AddPoints(_points);
            }
            ShowAddPoint(other.transform.position);
            UpdatePointsCounters();
            
            enemy.ExplodeOfWall();
            Destroy(other.gameObject);
        }
    }

    private void UpdatePointsCounters()
    {
        if (Game.Instance == null)
        {
            return;
        }

        int targetPoints = Game.Instance.LevelGoal.Goal;
        foreach (var counter in _counterTexts)
        {
            counter.text = $"Points: {Points}/{targetPoints}";
        }
    }

    private void ShowAddPoint(Vector2 position)
    {
        var addPoint = Instantiate(_addPointsPrefab,position, Quaternion.identity);
        addPoint.SetPoints(_points);
        Destroy(addPoint.gameObject, 3);
    }
}