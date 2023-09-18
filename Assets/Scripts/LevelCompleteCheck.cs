using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleteCheck : MonoBehaviour
{
    CardMarkers cardMarkers;
    CardMatchCheck cardMatchCheck;
    int cardsToMatch;
    public event Action onLevelComplete;
    private void Awake()
    {
        cardMarkers = GetComponent<CardMarkers>();
        cardMatchCheck = GetComponent<CardMatchCheck>();
        cardMatchCheck.onCardMatahed += CardsMatched;
    }
    private void Start()
    {
        Invoke(nameof(SetTotalCards),0.1f);
    }

    private void SetTotalCards()
    {
        cardsToMatch = cardMarkers.GetCardCount();
    }
    void CheckIfLevelIsComplete()
    {
        if(cardsToMatch == 0)
        {
            Debug.Log("Level Completed");
            Invoke(nameof(LevelComplete),0.5f);
        }
    }

    private void LevelComplete()
    {
        if (onLevelComplete != null)
        {
            onLevelComplete();
        }
    }

    void CardsMatched()
    {
        cardsToMatch -= 2;
        CheckIfLevelIsComplete();
    }
}
