using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompletePresenter : MonoBehaviour
{
    [SerializeField] private LevelCompleteCheck levelCompleteCheck;

    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextButton;

    private void Awake()
    {
        levelCompleteCheck.onLevelComplete += OnCompleteLevel;
    }
    void Start()
    {
        restartButton.onClick.AddListener(()=>RestartLevel());
        nextButton.onClick.AddListener(() => NextLevel());
    }

    void OnCompleteLevel()
    {
        levelCompletePanel.SetActive(true);
    }
    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
