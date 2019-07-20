using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject buildPrefab;
    private GameObject build;

    private HappyTreeGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("ActionButton"))
        {
            if (CanPlaceBuild())
            {
                build = (GameObject) Instantiate(buildPrefab, transform.position, Quaternion.identity);
                build.transform.parent = gameObject.transform;
                gameManager.Money -= build.GetComponent<BuildData>().CurrentLevel.cost;
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
    }
}