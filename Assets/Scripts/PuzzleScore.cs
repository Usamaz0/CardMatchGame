using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleScore : MonoBehaviour
{
    CardMatchCheck cardMatchCheck;
    int turns;
    int matches;
    int score;
    public event Action onTurnUpdated;
    public event Action onMatchesUpdated;


    private void Awake()
    {
        cardMatchCheck = GetComponent<CardMatchCheck>();
    }
    private void Start()
    {
        cardMatchCheck.onCardMismatahed += IncreaseTurns;
        cardMatchCheck.onCardMatahed += IncreaseTurns;
        cardMatchCheck.onCardMatahed += IncreaseMatches;
    }

    void IncreaseTurns()
    {
        turns++;
        if(onTurnUpdated != null )
        {  
            onTurnUpdated();
        }

    }
    void IncreaseMatches()
    {
        matches++;
        if(onMatchesUpdated != null )
        {
            onMatchesUpdated();
        }
    }
    public int GetTurns()
    {
        return turns;
    }
    public int GetMatches()
    {
        return matches;
    }
    public int GetScore()
    {
        return (int)(matches * 100)/turns;
    }
}
