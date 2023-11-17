using UnityEngine;

public class FadeLoadGameScreen : MonoBehaviour
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