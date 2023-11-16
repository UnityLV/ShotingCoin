using UnityEngine;

public class RandomSelector : MonoBehaviour
{
    [SerializeField] private GameObject[] _toSelect;

    private void Awake()
    {
        int targetIndex = UnityEngine.Random.Range(0, _toSelect.Length);

        for (int i = 0; i < _toSelect.Length; i++)
        {
            _toSelect[i].SetActive(i == targetIndex);
        }
    }
}