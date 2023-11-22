using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class EffectsSource : MonoBehaviour
{
    private void Awake()
    {
        if (Game.IsTest())
        {
            return;
        }

        var main = GetComponent<ParticleSystem>().main;
        main.playOnAwake = Game.Instance.Settings.GetIsEffectsEnabled();
        if (Game.Instance.Settings.GetIsEffectsEnabled() == false)
        {
            GetComponent<ParticleSystem>().Stop();
        }
    }

    private void OnEnable()
    {
        if (Game.IsTest())
        {
            return;
        }

        Game.Instance.Settings.OnEffectsEnabled += OnEffectsEnabled;
        Game.Instance.Settings.OnEffectsDisabled += OnEffectsDisabled;
    }

    private void OnDisable()
    {
        if (Game.IsTest())
        {
            return;
        }

        Game.Instance.Settings.OnEffectsEnabled -= OnEffectsEnabled;
        Game.Instance.Settings.OnEffectsDisabled -= OnEffectsDisabled;
    }

    private void OnEffectsDisabled()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.playOnAwake = false;
    }

    private void OnEffectsEnabled()
    {
        var main = GetComponent<ParticleSystem>().main;
        main.playOnAwake = true;
    }
}