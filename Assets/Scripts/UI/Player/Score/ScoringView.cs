using UnityEngine;
using UnityEngine.UI;

public class ScoringView : MonoBehaviour
{
    [SerializeField] private Scoring _scoring;
    [SerializeField] private Text _scoringText;
    public void Awake()
    {
        _scoring.OnScoreValueChangedEvent += OnScoreValueChanged;
    }

    private void OnScoreValueChanged(int score)
    {
        _scoringText.text = "Score: " + score;
    }
    
}