using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Advanceable : MonoBehaviour
{
    public List<Advanceable> nextForms;
    public int currentLevel = 0;

    public void AdvanceLevel()
    {
        if (currentLevel == 0)
        {
            this.gameObject.SetActive(true);
            ++currentLevel;
        }
        else
        {
            if (nextForms.Count == 0) return;
            
                nextForms[currentLevel - 1].AdvanceLevel();
                ++currentLevel;
                gameObject.SetActive(false);

        }
    }
}
