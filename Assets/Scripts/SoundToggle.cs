using System;
using UnityEngine;

[RequireComponent(typeof(UnityEngine.UI.Toggle))]
public class SoundToggle : MonoBehaviour
{
    private void OnEnable()
    {
        if (Game.Instance == null)
        {
            return;
        }
        GetComponent<UnityEngine.UI.Toggle>().isOn = Game.Instance.Settings.GetIsSoundEnabled();
    }

    public void Enable()
    {
        Game.Instance.Settings.SetIsSoundEnabled(true);
    }

    public void Disable()
    {
        Game.Instance.Settings.SetIsSoundEnabled(false);
    }
}