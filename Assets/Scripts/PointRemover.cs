using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PointRemover : MonoBehaviour
{
    [SerializeField] private AddPoints _addPointsPrefab;
    [SerializeField] private TMP_Text[] _counterTexts;
    [SerializeField] private int _points;
    [SerializeField] private UnityEvent _onDetect;
    public DefeatSystem DefeatSystem;

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
            HandlePoints(other);

            HandleEnemy(enemy);
            _onDetect?.Invoke();
        }
    }

    private void HandleEnemy(Enemy enemy)
    {
        enemy.ExplodeOfWall();
        Destroy(enemy.gameObject);
    }

    private void HandlePoints(Collider2D other)
    {
        ShowAddPoint(other.transform.position);
        UpdatePointsCounters();

        if (Game.IsTest())
        {
            return;
        }

        Game.Instance.LevelGoal.AddPoints(_points);
        
        if (Game.Instance.LevelGoal.Points < 0)
        {
            DefeatSystem.Defeat();
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
            counter.text = $"Points: {Game.Instance.LevelGoal.Points}-{targetPoints}";
        }
    }

    private void ShowAddPoint(Vector2 position)
    {
        var addPoint = Instantiate(_addPointsPrefab, position, Quaternion.identity);
        addPoint.SetPoints(_points);
        Destroy(addPoint.gameObject, 3);
    }
}