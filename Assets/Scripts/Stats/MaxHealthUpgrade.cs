using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealthUpgrade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("HappyTreeGameManager").GetComponent<HappyTreeGameManager>().UpgradeMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
