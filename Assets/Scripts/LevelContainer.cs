using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContainer : MonoBehaviour
{
    private int currentLevel
    {
        get { return PlayerPrefs.GetInt("currentLevel",0); }
        set { PlayerPrefs.SetInt("currentLevel", value); }
    }

    [SerializeField] private LevelInfo[] levelInfo;

    public int GetLevelGridRowCount()
    {
        return levelInfo[currentLevel].gridRowCount;
    }
    public int GetLevelGridColumnCount()
    {
        return levelInfo[currentLevel].gridColumnCount;
    }
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    public void IncreaseLevel()
    {
        currentLevel++;
        if(currentLevel >= levelInfo.Length)
        {
            currentLevel = 0;
        }
    }
}
