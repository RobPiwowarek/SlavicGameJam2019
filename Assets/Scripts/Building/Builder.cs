using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject buildPrefab; // hack
    public BuildingSelection buildingSelection;
    private GameObject build;
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
        if ((Input.GetButtonDown("ActionButton") || Input.GetButtonDown("ActionButton_Joystick")) && playerInRange)
        {
            Build();
        }
    }

    private bool CanPlaceBuild()
    {
        int cost = buildPrefab.GetComponent<BuildData>().levels[0].cost;
        return build == null && gameManager.Money >= cost; 
    }

    private bool CanUpgradeBuild()
    {
        if (build != null)
        {
            BuildData buildData = build.GetComponent<BuildData>();
            BuildLevel nextLevel = buildData.GetNextLevel();
            if (nextLevel != null)
            {
                return gameManager.Money >= nextLevel.cost;
            }
        }

        return false;
    }

    private void Build()
    {
        
        if (CanPlaceBuild())
        {
            build = (GameObject) Instantiate(buildPrefab, transform.position, Quaternion.identity);
            build.transform.parent = gameObject.transform;
            gameManager.Money -= build.GetComponent<BuildData>().CurrentLevel.cost * gameManager.buildingSpeedModifier;
            buildingSelection.gameObject.SetActive(false);
        }
        else if (CanUpgradeBuild())
        {
            var currentMaxHealth = build.GetComponent<BuildData>().CurrentMaxHealth;
            var currentHealth = build.GetComponent<Health>().healthPoints;
            build.GetComponent<BuildData>().IncreaseLevel();
            var levelMaxHealth = build.GetComponent<BuildData>().CurrentMaxHealth;
            build.GetComponent<Health>().maxHealth = levelMaxHealth;
            build.GetComponent<Health>().restoreHealth(levelMaxHealth - currentMaxHealth);
            gameManager.Money -= build.GetComponent<BuildData>().CurrentLevel.cost;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (build != null)
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