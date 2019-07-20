using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimChanger : MonoBehaviour
{
    public GameObject idleAnim;
    public GameObject runningAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<PlayerMovement>().isMoving())
        {
            idleAnim.SetActive(false);
            runningAnim.SetActive(true);
        }
        else
        {
            idleAnim.SetActive(true);
            runningAnim.SetActive(false);
        }
    }
}
