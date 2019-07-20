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
            if (nextForms.Count < currentLevel) return;
            Advanceable nextForm = nextForms[currentLevel - 1];
            // move Builders to nextform
            foreach (var componentsInChild in gameObject.GetComponentsInChildren<Builder>())
            {
                componentsInChild.transform.parent = nextForm.transform;
            }
            nextForm.AdvanceLevel();
            ++currentLevel;
            gameObject.SetActive(false);

        }
    }
}