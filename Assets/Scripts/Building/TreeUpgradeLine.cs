using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUpgradeLine : MonoBehaviour
{
    public List<GameObject> branches;
    public List<SpriteRenderer> previews;
    private int currentLevel = 0;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    public GameObject currentBranch()
    {
        return branches[currentLevel];
    }

    public SpriteRenderer currentBranchPreview()
    {
        return previews[currentLevel];
    }

    public bool IsMaxedOut()
    {
        return currentLevel >= branches.Count;
    }

    public void build()
    {
        if (IsMaxedOut())
        {
            Debug.Log("Not building, is maxed out");
            return;
        }
        Debug.Log("Building" + currentBranch().name);
        currentBranchPreview().gameObject.SetActive(false);
        currentBranch().SetActive(true);
        currentLevel++;
    }

    // Update is called once per frame
    void Update()
    {
    }
}