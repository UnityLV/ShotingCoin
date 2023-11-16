using UnityEngine;

public class FadeGroup : MonoBehaviour
{
    
    [SerializeField] private Fade[] _fades;
    
    public void FadeIn()
    {
        foreach (Fade fade in _fades)
        {
            fade.FadeIn();
        }
    }

    public void FadeOut()
    {
        foreach (Fade fade in _fades)
        {
            fade.FadeOut();
        }
    }
}