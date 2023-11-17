using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _targetPrefab;
    [SerializeField] private float _forceMagnitude = 1f;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _spawnRate = 1f;
    [SerializeField] private float _offset;

    private void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    private IEnumerator SpawnTarget()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_spawnRate, _spawnRate  + _offset));
            Rigidbody2D targetInstance = Instantiate(_targetPrefab, transform.position, Quaternion.identity);
            targetInstance.AddForce(_direction * _forceMagnitude, ForceMode2D.Impulse);
            targetInstance.AddTorque(.1f, ForceMode2D.Impulse);
            Destroy(targetInstance.gameObject, 10f);
        }
    }
}