using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _explodeOfWallEffect;
    [SerializeField] private GameObject _explodeOfWallEffectIce;

    [SerializeField] private GameObject _fireEffects;
    [SerializeField] private GameObject _iceEffects;
    private bool _isIce;
    public void ExplodeOfWall()
    {
        var effect = Instantiate(GetExplodeOfWallEffect(), transform.position + Vector3.back, GetExplodeOfWallEffect().transform.rotation);
        Destroy(effect, 4);
    }

    public void SwitchToIce()
    {
        GetComponentInChildren<Rigidbody2D>().gravityScale = 0.4f;

        _isIce = true;
        _fireEffects.SetActive(false);
        _iceEffects.SetActive(true);
    }

    private GameObject GetExplodeOfWallEffect()
    {
        if (_isIce)
        {
            return _explodeOfWallEffectIce;
        }
        return _explodeOfWallEffect;
    }
}