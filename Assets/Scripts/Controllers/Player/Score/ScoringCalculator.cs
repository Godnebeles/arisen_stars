using UnityEngine;

public class ScoringCalculator : MonoBehaviour
{
    [SerializeField] private Scoring _scoring;
    public void AddScore()
    {
        _scoring.Add(100);
    }
}
