using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField] private GameObject[] _gameActionObjects;
    [SerializeField] private GameObject _tutorial;

    public void Awake()
    {
        if (Game.IsTest())
        {
            return;
        }
        
        if (Game.Instance.Settings.IsNeedToShowTutorial)
        {
            ShowTutorial();
            Game.Instance.Settings.IsNeedToShowTutorial = false;
            return;
        }

        EnableObjects();
    }

    private void ShowTutorial()
    {
        _tutorial.gameObject.SetActive(true);
    }
    
    public void OnTutorialClose()
    {
        _tutorial.gameObject.SetActive(false);
        EnableObjects();
    }

    private void EnableObjects()
    {
        foreach (var gameActionObject in _gameActionObjects)
        {
            gameActionObject.SetActive(true);
        } 
    }

   
}