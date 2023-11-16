using System;
using UnityEngine;

public class FadeLoadGameScren : MonoBehaviour
{
    public Fade Fade;

    private void OnEnable()
    {
        Fade.FadeOut();
        Game.Instance.LevelLoader.StartLevelLoad += InstanceOnStartLevelLoad;
    }

    private void OnDisable()
    {
        Game.Instance.LevelLoader.StartLevelLoad -= InstanceOnStartLevelLoad;
    }

    private void InstanceOnStartLevelLoad()
    {
        Fade.FadeIn();
    }
}