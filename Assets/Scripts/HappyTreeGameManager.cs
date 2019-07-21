using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyTreeGameManager : MonoBehaviour
{
    public HappyTree tree;
    public Health treeHealth;
    
    public Text moneyLabel;

    private float money;

    public void Awake()
    {
        Time.timeScale = 0.0f;
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        GameObject.Find("MENU").SetActive(false);
        GameObject.Find("INGAME").SetActiveRecursively(true);
        moneyLabel = GameObject.Find("Coins")?.GetComponent<Text>();
    }

    public void Start()
    {
        Money = 1000;
    }

    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            //moneyLabel.GetComponent<Text>().text = "Money: " + money;
        }
    }
    public void Update()
    {
        GameObject heart = GameObject.FindWithTag("Hearth");
        if (moneyLabel) moneyLabel.text = "Money: " + money;
        if (!heart)
        {
            Time.timeScale = 0.0f;
            GameObject.Find("INGAME").SetActive(false);
            GameObject.Find("END").gameObject.SetActiveRecursively(true);
        }
    }

    public float buildingSpeedModifier = 1.0f;
    public float towerDamageModifier = 1.0f;
    public float damageReductionModifier = 1.0f;
    public float attackSpeedModifier = 1.0f;
    public float maxHealthModifier = 1.0f;

    public void UpgradeBuildingSpeed()
    {
        buildingSpeedModifier += 0.1f;
    }

    public void UpgradeTowerDamage()
    {
        towerDamageModifier += 0.1f;
    }

    public void UpgradeDamageReduction()
    {
        damageReductionModifier -= 0.1f;
    }

    public void UpgradeAttackSpeed()
    {
        attackSpeedModifier -= 0.1f;
    }

    public void UpgradeMaxHealth()
    {
        maxHealthModifier += 0.1f;
        treeHealth.maxHealthPoints *= maxHealthModifier;
    }
}
