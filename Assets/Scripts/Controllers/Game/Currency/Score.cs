using System;
using UnityEngine;


public class Score : MonoBehaviour
{
    public event Action<int> OnScoreValueChangedEvent;

    public int ScoreValue { get; private set; }
    public int MaxScoreValue { get; private set; }

    public void Add(int score)
    {
        ScoreValue += score;

        OnScoreValueChangedEvent?.Invoke(ScoreValue);
    }

   
}