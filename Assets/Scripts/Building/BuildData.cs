using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class BuildLevel
{
    public int cost = 150;
    public GameObject visualization;
    public float maxHealth;
    
}

public class BuildData : MonoBehaviour
{
    private HappyTreeGameManager gameManager;
    private BuildLevel currentLevel;
    public List<BuildLevel> levels;
    
    void Start()
    {
        
        gameManager = GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>();

    }

    void Update()
    {
    }

    public float CurrentMaxHealth
    {
        get
        {
            int currentLevelIndex = levels.IndexOf(currentLevel);
            float levelMaxHealth = levels[currentLevelIndex].maxHealth;
            return levelMaxHealth;
        }
    }

    public BuildLevel CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;
            int currentLevelIndex = levels.IndexOf(currentLevel);

            GameObject levelVisualization = levels[currentLevelIndex].visualization;
            for (int i = 0; i < levels.Count; i++)
            {
                if (levelVisualization != null)
                {
                    if (i == currentLevelIndex)
                    {
                        levels[i].visualization.SetActive(true);
                    }
                    else
                    {
                        levels[i].visualization.SetActive(false);
                    }
                }
            }
        }
    }

    void OnEnable()
    {
        CurrentLevel = levels[0];
    }

    public BuildLevel GetNextLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        int maxLevelIndex = levels.Count - 1;
        if (currentLevelIndex < maxLevelIndex)
        {
            return levels[currentLevelIndex + 1];
        }
        else
        {
            return null;
        }
    }

    public void IncreaseLevel()
    {
        int currentLevelIndex = levels.IndexOf(currentLevel);
        if (currentLevelIndex < levels.Count - 1)
        {
            CurrentLevel = levels[currentLevelIndex + 1];
        }
    }
}