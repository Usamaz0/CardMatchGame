using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PuzzleBoard : MonoBehaviour
{
    [SerializeField] private Transform puzzleBoard;
    [SerializeField] private GridLayoutGroup puzzleGridLayoutGroup;
    [SerializeField] private GameObject puzzleCardPrefab;

    int gridRowCount = 2;
    int gridColumnCount = 2;

    public event Action onCardBoardGenerated;
    public UnityEvent onPuzzleBoardGeneratedEvent;

    [SerializeField] private LevelContainer levelContainer;

    private void Awake()
    {
        gridRowCount = levelContainer.GetLevelGridRowCount();
        gridColumnCount = levelContainer.GetLevelGridColumnCount();
    }
    // Start is called before the first frame update
    void Start()
    {
        puzzleGridLayoutGroup.constraintCount = gridColumnCount; // set Grid Size
        AdjustCardSize();
        PopulatePuzzleBoard();
        if (onCardBoardGenerated != null)
        {
            onCardBoardGenerated();
        }
        Invoke(nameof(BoardReady),0.1f);
    }

    private void BoardReady()
    {
        if (onPuzzleBoardGeneratedEvent != null)
        {
            onPuzzleBoardGeneratedEvent.Invoke();
        }
    }

    void PopulatePuzzleBoard()
    {
        for (int i = 0; i < GetGridSize(); i++)
        {
            Instantiate(puzzleCardPrefab, puzzleBoard, false);
        }
    }
    void AdjustCardSize()
    {
        Vector2 currentCardSize = puzzleGridLayoutGroup.cellSize;
        Vector2 currentCardSpacing = puzzleGridLayoutGroup.spacing;

        if (gridRowCount > 4 || gridColumnCount > 4)
        {
            float difference = gridRowCount > gridColumnCount ? gridRowCount * 0.25f : gridColumnCount * 0.25f;
            currentCardSize /= difference;
            currentCardSpacing /= difference;
            puzzleGridLayoutGroup.spacing = currentCardSpacing;
            puzzleGridLayoutGroup.cellSize = currentCardSize;
        }
    }
    public int GetGridSize()
    {
        return gridColumnCount * gridRowCount;
    }
}
