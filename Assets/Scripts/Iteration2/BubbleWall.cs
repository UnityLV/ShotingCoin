using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Iteration2
{

    public class BubbleWall : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPopPrefab;
        
        [SerializeField] private UnityEvent _onDisable;
        
        private void OnDisable()
        {
            _onDisable.Invoke();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                Instantiate(_enemyPopPrefab, enemy.transform.position, Quaternion.identity);
                Destroy(enemy.gameObject);
            }
        }
    }
}