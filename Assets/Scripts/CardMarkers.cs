using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardMarkers : MonoBehaviour
{
    [SerializeField] private Sprite[] cardSprites;
    [SerializeField] private Transform puzzleBoard;
    PuzzleBoard board;
    Button[] cards;
    private void Awake()
    {
        board = GetComponent<PuzzleBoard>();
        board.onCardBoardGenerated += AssignCarMarkers;
    }

    void AssignCarMarkers()
    {
        cards  = puzzleBoard.GetComponentsInChildren<Button>();
        int boardHalfSize = board.GetGridSize() / 2;
        for (int i = 0; i < boardHalfSize; i++)
        {
            AddButtonListener(i, i);
            AddButtonListener(i + boardHalfSize, i);
        }
    }

    private void AddButtonListener(int index, int cardIndex)
    {
        cards[index].onClick.AddListener(() => CardClick(cardIndex));
    }

    void CardClick(int index)
    {
        Debug.Log("Selected Card Index is:" + index);
    }
}
