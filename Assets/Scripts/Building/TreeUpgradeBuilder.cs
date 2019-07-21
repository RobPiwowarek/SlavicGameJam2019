using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeUpgradeBuilder : MonoBehaviour
{
    public TreeUpgradeBuildingSelection buildingSelection;
    public int upgradeCost;
    private bool playerInRange;
    private HappyTreeGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerInRange)
        {
            return;
        }
        if (Input.GetButtonDown("ActionButton"))
        {
            Build();
        }
        else if (Input.GetButtonDown("SelectLeft"))
        {
            buildingSelection.prev();
        }
        else if (Input.GetButtonDown("SelectRight"))
        {
            buildingSelection.next();
        }
    }

    private bool CanPlaceBuild()
    {
        return gameManager.Money >= upgradeCost; 
    }

    private void Build()
    {
        if (CanPlaceBuild())
        {
            gameManager.Money -= upgradeCost;
            buildingSelection.build();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        buildingSelection.gameObject.SetActive(true);
        playerInRange = true;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        buildingSelection.gameObject.SetActive(false);
        playerInRange = false;
    }
}