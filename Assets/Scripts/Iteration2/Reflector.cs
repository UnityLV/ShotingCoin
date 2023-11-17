using UnityEngine;

namespace Iteration2
{
    public class Reflector : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.TryGetComponent(out Enemy enemy))
            {
                enemy.SwitchToPlayerAttack();
            }
        }
    }
}