using UnityEngine;

namespace Iteration2
{
    public class TorqueResistor : MonoBehaviour
    {
        [SerializeField] private float _maxTorque;
        [SerializeField] private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {

        }
    }
}