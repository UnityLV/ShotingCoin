using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Iteration2
{
    public class CanonShoot : MonoBehaviour
    {
        [SerializeField] private float _repeatRate = 0.5f;
        [SerializeField] private float _shootSpeed = 10f;
        [SerializeField] private float _startDelay = 3f;
        [SerializeField] private Rigidbody2D _missilePrefab;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private UnityEvent _onShoot;

        private void Awake()
        {
            InvokeRepeating(nameof(Shoot), _startDelay, _repeatRate);
        }

        private void Shoot()
        {
            var missile = Instantiate(_missilePrefab, _spawnPosition.position, Quaternion.identity);
            missile.AddForce(transform.up * _shootSpeed, ForceMode2D.Impulse);
            missile.AddTorque(.1f, ForceMode2D.Impulse);
            Destroy(missile.gameObject, 10f);
            _onShoot?.Invoke();
        }
    }
}