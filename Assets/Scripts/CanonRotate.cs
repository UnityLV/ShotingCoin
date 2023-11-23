using UnityEngine;

namespace Iteration2
{
    
    public class CanonRotate : MonoBehaviour
    {
        public void Rotate(float speed)
        {
            transform.Rotate(0, 0, speed);
            ClampRotation();
        }

        private void ClampRotation()
        {
            float leftBound = 50;
            float rightBound = 360 - leftBound;
            float rotation = transform.localRotation.eulerAngles.z;

            if (rotation > leftBound && rotation < 180)
            {
                transform.localRotation = Quaternion.Euler(0, 0, leftBound);
            }

            if (rotation < rightBound && rotation > 180)
            {
                transform.localRotation = Quaternion.Euler(0, 0, rightBound);
            }
        }
    }
}