using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleBoard : MonoBehaviour
{
    [SerializeField] private Transform puzzleBoard;
    [SerializeField] private GridLayoutGroup puzzleGridLayoutGroup;
    [SerializeField] private GameObject puzzleCardPrefab;
    [SerializeField] private int gridRowCount = 2;
    [SerializeField] private int gridColumnCount = 2;

    // Start is called before the first frame update
    void Start()
    {
        puzzleGridLayoutGroup.constraintCount = gridColumnCount; // set Grid Size
        AdjustCardSize();
        PopulatePuzzleBoard();
    }
    void PopulatePuzzleBoard()
    {
        for (int i = 0; i < gridColumnCount * gridRowCount; i++)
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
}
