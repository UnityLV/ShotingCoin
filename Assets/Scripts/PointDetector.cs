using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointDetector : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _counterTexts;
    [SerializeField] private int _points;
    [SerializeField] private UnityEvent _onDetect;
    
    private int Points => Game.Instance.LevelGoal.Points;

    private void Start()
    {
        if (Game.IsTest() == false)
        {
            Game.Instance.LevelGoal.Reset();
        }

        UpdatePointsCounters();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Enemy enemy))
        {
            if (Game.IsTest() == false)
            {
                Game.Instance.LevelGoal.AddPoints(_points);
            }

            UpdatePointsCounters();

            enemy.ExplodeOfWall();
            Destroy(other.gameObject);
            _onDetect?.Invoke();
        }
    }

    private void UpdatePointsCounters()
    {
        if (Game.IsTest())
        {
            return;
        }

        int targetPoints = Game.Instance.LevelGoal.Goal;
        foreach (var counter in _counterTexts)
        {
            counter.text = $"Points: {Points}-{targetPoints}";
        }
    }

   
}