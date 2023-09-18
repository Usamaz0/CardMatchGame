using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleScorePresenter : MonoBehaviour
{
    [SerializeField] private PuzzleScore puzzleScore;
    [SerializeField] private TextMeshProUGUI turnScoreText;
    [SerializeField] private TextMeshProUGUI matchScoreText;

    // Start is called before the first frame update
    void Start()
    {
        puzzleScore.onTurnUpdated += UpdateTurnScore;
        puzzleScore.onMatchesUpdated += UpdateMatchScore;
    }

    void UpdateTurnScore()
    {
        turnScoreText.text = "Turns : " + puzzleScore.GetTurns();
    }
    void UpdateMatchScore()
    {
        matchScoreText.text = "Matchs : " + puzzleScore.GetMatches();
    }
}
