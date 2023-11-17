using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class LevelSettings
{
    public int Level = 1;
    public int Goal = 10;
}

public enum LevelState
{
    Current,
    Completed,
    Closed,
    
}

[RequireComponent(typeof(Button))]
public class LevelButton : MonoBehaviour
{
    public LevelSettings _settings;

    public Image CompleateImage;
    public Image NotCompleateImage;
    public Image CurrentImage;

    public LevelState State;

    private void OnValidate()
    {
    _settings.Level = transform.GetSiblingIndex() + 1;
        _settings.Goal = ((_settings.Level + 1) * 15) + 30;
    }

    private async void Awake()
    {
        await Task.Delay(1);
        GetComponent<Button>().onClick.AddListener(LoadLevel);
        SetView();
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void SetView()
    {
        if (Game.Instance.LevelCompleteCondition.IsThisLastUncompleted(_settings.Level))
        {
            SetAsCurrent();
            return;
        }

        if (Game.Instance.LevelCompleteCondition.IsThisLevelCompleted(_settings.Level))
        {
            SetAsCompleted();
            return;
        }

        SetAsNotCompleted();
    }

    public void SetAsCurrent()
    {
        CompleateImage.gameObject.SetActive(false);
        NotCompleateImage.gameObject.SetActive(false);
        CurrentImage.gameObject.SetActive(true);
        GetComponent<Button>().interactable = true;
        State = LevelState.Current;
    }

    public void SetAsCompleted()
    {
        CompleateImage.gameObject.SetActive(true);
        NotCompleateImage.gameObject.SetActive(false);
        CurrentImage.gameObject.SetActive(false);
        GetComponent<Button>().interactable = true;
        State = LevelState.Completed;
    }

    public void SetAsNotCompleted()
    {
        CompleateImage.gameObject.SetActive(false);
        NotCompleateImage.gameObject.SetActive(true);
        CurrentImage.gameObject.SetActive(false);
        GetComponent<Button>().interactable = false;
        State = LevelState.Closed;
    }

    private void LoadLevel()
    {
        Game.Instance.LevelLoader.LoadLevel(_settings);
        
    }
}