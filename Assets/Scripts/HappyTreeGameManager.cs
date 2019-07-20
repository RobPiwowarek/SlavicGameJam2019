using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyTreeGameManager : MonoBehaviour
{
    public Tree tree;
    public Health treeHealth;
    
    public Text moneyLabel;

    private float money;
    
    public float Money
    {
        get
        {
            return money;
        }
        set
        {
            money = value;
            moneyLabel.GetComponent<Text>().text = "Money: " + money;
        }
    }
    
    private float buildingSpeedModifier = 1.0f;
    private float towerDamageModifier = 1.0f;
    private float damageReductionModifier = 1.0f;
    private float attackSpeedModifier = 1.0f;
    private float maxHealthModifier = 1.0f;

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
