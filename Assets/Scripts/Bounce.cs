using UnityEngine;

public class Bounce : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 10f;

    private void OnCollisionEnter2D(Collision2D other)
    {
        BounceOf(other);
    }

    private void BounceOf(Collision2D other)
    {
        Rigidbody2D rb = other.rigidbody;
        if (rb != null)
        {
            Vector2 direction = CalculateReflectionVector(rb.velocity);
            rb.velocity = direction * _bounceForce;
        }
    }

    private Vector2 CalculateReflectionVector(Vector2 rbVelocity)
    {
        return Vector2.Reflect(rbVelocity, transform.right);
    }
}