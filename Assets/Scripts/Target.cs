using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject _splashEffect;
  
    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
    public void SplashEffect()
    {
        var effect = Instantiate(_splashEffect, transform.position + Vector3.back, Quaternion.identity);
        Destroy(effect, 4);
    }
}