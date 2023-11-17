using UnityEngine;
using UnityEngine.EventSystems;

namespace Iteration2
{
    public class MoveCanonButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
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
     
        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isPressed = false;
        }
    }
}