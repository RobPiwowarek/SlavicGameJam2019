using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUpgradeBuildingSelection : MonoBehaviour
{
    public List<TreeUpgradeLine> selections;
    public int currentSelectionIdx = 0;

    public GameObject GetUpgradeToBuild()
    {
        return selections[currentSelectionIdx].currentBranch();
    }
    
    void update()
    {
        if (selections.Count <= 0)
        {
            return;
        }

        foreach (var selection in selections)
        {
            selection.gameObject.SetActive(false);
        }

        selections[currentSelectionIdx].gameObject.SetActive(true);
    }
    
    public void next()
    {
        currentSelectionIdx = (currentSelectionIdx + 1) % selections.Count;
        update();
    }

    public void prev()
    {
        currentSelectionIdx = (currentSelectionIdx - 1);
        if (currentSelectionIdx < 0)
        {
            currentSelectionIdx = selections.Count - 1;
        }
        update();
    }

    public void build()
    {
        Debug.Log("Building" + selections[currentSelectionIdx].name);
        selections[currentSelectionIdx].build();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        update();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
