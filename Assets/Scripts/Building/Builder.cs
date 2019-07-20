using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public GameObject buildPrefab;
    private GameObject build;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private bool CanPlaceBuild()
    {
        int cost = buildPrefab.GetComponent<BuildData>().levels[0].cost;
        return build == null; //&& gameManager.Money >= cost; 
    }
    
    private bool CanUpgradeBuild()
    {
        if (build != null)
        {
            BuildData buildData = build.GetComponent<BuildData>();
            BuildLevel nextLevel = buildData.GetNextLevel();
            if (nextLevel != null)
            {
                return true; //gameManager.Money >= nextLevel.cost;
            }
        }
        return false;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetButtonDown("ActionButton"))
        {
//            var basicBuild = Instantiate ( buildPrefab, gameObject.transform );
//            basicBuild.transform.parent = gameObject.transform;
            if (CanPlaceBuild())
            {
                build = (GameObject) Instantiate(buildPrefab, transform.position, Quaternion.identity);
                build.transform.parent = gameObject.transform;
                //gameManager.Money -= build.GetComponent<BuildData>().CurrentLevel.cost;
            }
            else if (CanUpgradeBuild())
            {
                Debug.Log(build.GetComponent<BuildData>().CurrentLevel.ToString());
                build.GetComponent<BuildData>().IncreaseLevel();
                var levelMaxHealth = build.GetComponent<BuildData>().CurrentMaxHealth;
                build.GetComponent<Health>().maxHealth = levelMaxHealth;

                //gameManager.Money -= build.GetComponent<BuildData>().CurrentLevel.cost;
            }
        }
    }

}
