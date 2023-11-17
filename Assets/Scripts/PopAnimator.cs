using System;
using DG.Tweening;
using UnityEngine;

public class PopAnimator : MonoBehaviour
{
    [SerializeField] private float _scale = 2;
    [SerializeField] private float _duration = 1;

    [SerializeField] private Ease _easeIn;
    [SerializeField] private Ease _easeOut;
    
    [SerializeField] private Transform _toAnimate;
     
    private Vector3 _defaultScale;

    private void Start()
    {
        _defaultScale = _toAnimate.localScale;
    }

    public async void Animate()
    {
        _toAnimate.DOKill();
        _toAnimate.localScale = _defaultScale;
        await _toAnimate.DOScale(_scale, _duration).SetEase(_easeIn).AsyncWaitForCompletion();
        await _toAnimate.DOScale(_defaultScale, _duration).SetEase(_easeOut).AsyncWaitForCompletion();
    }
}