using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardMatchCheck : MonoBehaviour
{
    public enum GuessState
    {
        FirstGuess,
        SecondGuess
    }
    CardMarkers cardMarkers;
    public event Action onTurnUpdated;
    public event Action onCardMatahed;
    public event Action onCardMismatahed;
    GuessState guessState = GuessState.FirstGuess;
    int lastSelectedIndex =-1;

    private void Awake()
    {
        cardMarkers = GetComponent<CardMarkers>();
    }
    private void Start()
    {
        cardMarkers.onCardClick += ChangeGuessState;
    }
    void ChangeGuessState(int index)
    {
        if(onTurnUpdated != null)
        {
            onTurnUpdated();
        }

        if (guessState == GuessState.FirstGuess)
        {
            lastSelectedIndex = index;
            guessState = GuessState.SecondGuess;
        }
        else
        {
            // Second Guess
            guessState = GuessState.FirstGuess;
            CompareCards(index);
            ResetLastSelectedIndex();
        }
    }
    void CompareCards(int index)
    {
        if (lastSelectedIndex == index)
        {
            // card Matched
            Debug.Log("Cards Matched");
            if (onCardMatahed != null)
            {
                onCardMatahed();
            }
        }
        else
        {
            if(onCardMismatahed != null)
            {
                onCardMismatahed();
            }
        }
    }
    void ResetLastSelectedIndex()
    {
        lastSelectedIndex = -1;
    }
}
