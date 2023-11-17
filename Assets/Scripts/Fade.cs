using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;

public class Fade : MonoBehaviour
{
    [SerializeField] private float _durationIn = 1f;
    [SerializeField] private float _durationOut = 1f;
    
    [SerializeField] private float _delayIn;
    [SerializeField] private float _delayOut;
    
    [SerializeField] private CanvasGroup _canvasGroup;
    

    public async void FadeIn()
    {
        await Task.Delay((int)(_delayIn * 1000));
        if (_canvasGroup == null)
        {
            return;
        }
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(1f, _durationIn);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }

    public async void FadeOut()
    {
        await Task.Delay((int)(_delayOut * 1000));
        if (_canvasGroup == null)
        {
            return;
        }
        _canvasGroup.DOKill();
        _canvasGroup.DOFade(0f, _durationOut);
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }
}