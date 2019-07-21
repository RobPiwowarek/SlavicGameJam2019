using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyTree : MonoBehaviour
{
    public int _currentLevel = 0;
    public MasterList values;

    private float _time = 0f;
    private float advanceTime = 2f;

    public void AdvanceLevel()
    {
        if (_currentLevel >= values.list.Count) return;
        
        foreach (Advanceable o in values.list[_currentLevel].ContainedList)
        {
            o.AdvanceLevel();
        }
        _currentLevel++;
        
        AstarPath.active.Scan();
    }


    private void Update()
    {
//        _time = _time + Time.deltaTime;
//        //Debug.Log(_time);
//        if (_time > advanceTime)
//        {
//            _time = 0f;
//            AdvanceLevel();
//        }
    }

    [System.Serializable]
    public class ListContainer
    {
        public List<Advanceable> ContainedList = new List<Advanceable>();
    }
    
    [System.Serializable]
    public class MasterList
    {
        public List<ListContainer> list = new List<ListContainer>();
    }
}
