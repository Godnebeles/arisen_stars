using System;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public event Action<ScoreData> OnHighScoreValuesChangedEvent;
    private ScoreData _scoreData;

    private void Awake()
    {
        _scoreData.hightScore = PlayerPrefs.GetInt("HighScore");
        _scoreData.previewScore = PlayerPrefs.GetInt("PreviewScore");
    }

    private void Start()
    {
        OnHighScoreValuesChangedEvent?.Invoke(_scoreData);
    }
}
