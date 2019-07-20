using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDamageUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>().UpgradeTowerDamage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
