using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffensiveBuildData : MonoBehaviour
{

    [SerializeField] private GameObject bullet;
    [SerializeField] private float seconds;
    [SerializeField] private Transform firePoint;
    void Start()
    {
        StartCoroutine(CheckIfTimePassed());
    }
    
    IEnumerator CheckIfTimePassed() {
        for(;;)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation).GetComponent<Transform>();
            yield return new WaitForSeconds(seconds);
        }
    }
}