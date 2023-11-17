using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MainMenuStartButton : MonoBehaviour
{
    [SerializeField] private LevelButton[] _levelButtons;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadLevel);
    }

    private void OnDestroy()
    {
        GetComponent<Button>().onClick.RemoveAllListeners();
    }

    private void LoadLevel()
    {
        Game.Instance.LevelLoader.LoadLevel(GetLevelToLoad());
    }

    private LevelSettings GetLevelToLoad()
    {
       var pendingButton = _levelButtons.FirstOrDefault(b => b.State == LevelState.Current);

       if ( pendingButton != null)
       {
           return pendingButton._settings;
       }
       return _levelButtons[Random.Range(0, _levelButtons.Length)]._settings;
    }
}