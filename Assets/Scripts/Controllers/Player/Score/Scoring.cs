using System;
using UnityEngine;


public class Scoring : MonoBehaviour
{
    public event Action<int> OnScoreValueChangedEvent;

    private int _score;

    public void Add(int score)
    {
        _score += score;

        OnScoreValueChangedEvent?.Invoke(_score);
    }
}