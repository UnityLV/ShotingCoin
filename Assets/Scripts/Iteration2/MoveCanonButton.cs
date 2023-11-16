using UnityEngine;
using UnityEngine.Serialization;

namespace Iteration2
{
    public class MoveCanonButton : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private CanonRotate _canonRotate;
        private bool _isPressed;

        private void Update()
        {
            if (_isPressed)
            {
                _canonRotate.Rotate(_speed);
            }
        }
        
        public void PointerDown()
        {
            _isPressed = true;
        }

      

        public void PointerUp()
        {
            _isPressed = false;
        }
    }
}