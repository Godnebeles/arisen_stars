using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ScoringView : MonoBehaviour
{
    [FormerlySerializedAs("_scoring")] [SerializeField] private Score score;
    [SerializeField] private Text _scoringText;
    public void Awake()
    {
        score.OnScoreValueChangedEvent += OnScoreValueChanged;
    }

    private void OnScoreValueChanged(int score)
    {
        _scoringText.text = "Score: " + score;
    }
    
}