using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private Score _score;
    public void AddScore()
    {
        _score.Add(100);
    }
}
