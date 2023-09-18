using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CardMarkers : MonoBehaviour
{
    [SerializeField] private Sprite cardBack;
    [SerializeField] private Sprite[] cardSprites;
    [SerializeField] private Transform puzzleBoard;
    PuzzleBoard board;
    Button[] cards;
    public delegate void CallbackType(int index);
    public event CallbackType onCardClick;

    List<int> cardsToHide = new List<int>();
    CardMatchCheck matchCheck;
    private void Awake()
    {
        board = GetComponent<PuzzleBoard>();
        matchCheck = GetComponent<CardMatchCheck>();
        board.onCardBoardGenerated += AssignCarMarkers;
        matchCheck.onCardMismatahed += HideMarkersWithDelay;
        matchCheck.onCardMatahed += DisableMarkersWithDelay;
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
        ShuffleMarkers();
    }

    private void AddButtonListener(int index, int cardIndex)
    {
        cards[index].onClick.AddListener(() => CardClick(index, cardIndex));
    }

    void CardClick(int index,int cardIndex)
    {
        Debug.Log("Selected Card Index is:" + index);
        ShowMarker(index, cardIndex);
        cards[index].interactable = false;
        if (onCardClick != null)
        {
            onCardClick(cardIndex);
        }
    }
    void ShowMarker(int index, int cardIndex)
    {
        cardsToHide.Add(index);
        cards[index].image.sprite = cardSprites[cardIndex];
    }
    IEnumerator HideMarker(List<int> cardsToHideList)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0;i < cardsToHideList.Count;i++)
        {
            cards[cardsToHideList[i]].image.sprite = cardBack;
            cards[cardsToHideList[i]].interactable = true;
        }
    }
    void HideMarkersWithDelay()
    {
        StartCoroutine(HideMarker(cardsToHide));
        cardsToHide = new List<int>();
    }

    void DisableMarkersWithDelay()
    {
        StartCoroutine(DisableMarker(cardsToHide));
        cardsToHide = new List<int>();
    }
    IEnumerator DisableMarker(List<int> cardsToHideList)
    {
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < cardsToHideList.Count; i++)
        {
            cards[cardsToHideList[i]].gameObject.SetActive(false);
        }
    }
    void ShuffleMarkers()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            int indexInHierarchy = cards[i].transform.GetSiblingIndex();
            int randomIndex = UnityEngine.Random.Range(i, cards.Length);
            cards[indexInHierarchy].transform.SetSiblingIndex(randomIndex);
            cards[randomIndex].transform.SetSiblingIndex(indexInHierarchy);
        }
    }
    public int GetCardCount()
    {
        return cards.Length;
    }
}
