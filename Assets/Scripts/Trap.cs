using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private GameObject _explodeOfPlayerEffect;
    
    public void ExplodeOfWall()
    {
        var effect = Instantiate(_explodeOfPlayerEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4);
    }
}