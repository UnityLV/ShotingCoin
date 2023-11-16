using TMPro;
using UnityEngine;

public class AddPoints : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    public void SetPoints(int points)
    {
        _text.text = points.ToString();
    }
}