using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSelection : MonoBehaviour
{
    public List<GameObject> prefabs;
    public List<Sprite> prefabIcons;
    private int selectedPrefabIdx = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        update();
    }

    public GameObject selectedPrefab()
    {
        return prefabs[selectedPrefabIdx];
    }

    public Sprite selectedIcon()
    {
        return prefabIcons[selectedPrefabIdx];
    }

    void update()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = selectedIcon();
        gameObject.GetComponentInParent<Builder>().buildPrefab = selectedPrefab();
    }

    void next()
    {
        selectedPrefabIdx = (selectedPrefabIdx + 1) % prefabs.Count;
        update();
    }

    void prev()
    {
        selectedPrefabIdx = (selectedPrefabIdx - 1);
        if (selectedPrefabIdx < 0)
        {
            selectedPrefabIdx = prefabs.Count - 1;
        }
        update();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SelectLeft"))
        {
            prev();
        }
        else if (Input.GetButtonDown("SelectRight"))
        {
            next();
        }
    }
}
