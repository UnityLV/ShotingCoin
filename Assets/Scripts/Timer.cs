using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private DateTime _startTime;

    private void OnEnable()
    {
        StartCount();
    }

    public void StartCount()
    {
        _startTime = DateTime.Now;
    }

    public void StopCount()
    {
        int seconds = (int)(DateTime.Now - _startTime).TotalSeconds;
        _text.text = $"{seconds} SECONDS";
    }
}