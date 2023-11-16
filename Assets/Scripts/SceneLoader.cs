using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


public class SceneLoader : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    [SerializeField] private float _delay;
    private bool isLoaded;

    public async void Load()
    {
        if (isLoaded)
        {
            return;
        }
        isLoaded = true;
        await Task.Delay((int)(_delay * 1000));
        UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(_sceneName);
    }
}