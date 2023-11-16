using UnityEngine;

public class EffectsToggle : MonoBehaviour
{
    private void OnEnable()
    {
        if (Game.Instance == null)
        {
            return;
        }
        GetComponent<UnityEngine.UI.Toggle>().isOn = Game.Instance.Settings.GetIsEffectsEnabled();
    }
    
    public void Enable()
    {
        Game.Instance.Settings.SetIsEffectsEnabled(true);
    }

    public void Disable()
    {
        Game.Instance.Settings.SetIsEffectsEnabled(false);
    }
}