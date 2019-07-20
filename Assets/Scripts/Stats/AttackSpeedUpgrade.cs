using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpeedUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>().UpgradeAttackSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
