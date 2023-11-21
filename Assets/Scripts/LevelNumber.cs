using TMPro;
using UnityEngine;

[RequireComponent(typeof(LevelButton))]
public class LevelNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void OnValidate()
    {
        _text.text = GetComponent<LevelButton>().GetLevel().ToString();
    }
}