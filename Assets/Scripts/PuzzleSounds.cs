using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSounds : MonoBehaviour
{
    CardMatchCheck cardMatchCheck;
    LevelCompleteCheck levelCompleteCheck;

    [SerializeField] private AudioClip flipCardSfx;
    [SerializeField] private AudioClip cardMatchedSfx;
    [SerializeField] private AudioClip cardMismatchedSfx;
    [SerializeField] private AudioClip gameCompleteSfx;
    [SerializeField] private AudioSource puzzleAudioSource;

    private void Awake()
    {
        cardMatchCheck = GetComponent<CardMatchCheck>();
        levelCompleteCheck = GetComponent<LevelCompleteCheck>();
        cardMatchCheck.onTurnUpdated += PlayFlipCardSfx;
        cardMatchCheck.onCardMatahed += PlayCardMatchedSfx;
        cardMatchCheck.onCardMismatahed += PlayCardMismatchedSfx;
        levelCompleteCheck.onLevelComplete += PlayPuzzleWinSfx;
    }

    void PlayFlipCardSfx()
    {
        puzzleAudioSource.PlayOneShot(flipCardSfx);
    }
    void PlayCardMatchedSfx()
    {
        puzzleAudioSource.PlayOneShot(cardMatchedSfx);
    }
    void PlayCardMismatchedSfx()
    {
        puzzleAudioSource.PlayOneShot(cardMismatchedSfx);
    }
    void PlayPuzzleWinSfx()
    {
        puzzleAudioSource.PlayOneShot(gameCompleteSfx);
    }
}
