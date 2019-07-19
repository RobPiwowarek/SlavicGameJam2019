using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLine : MonoBehaviour
{
    public float damage = 5f;
    public LineRenderer line;
    public Transform firePoint;
    public CameraShake shake = null;
    public float shakeDuration = 0.25f;
    
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right);
        
        if (hit)
        {
            
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, hit.point);

            if (shake != null)
                shake.shakeDuration = shakeDuration;

            Health health = hit.transform.GetComponent<Health>();
            if (health != null)
                health.takeDamage(damage);
        }
        else
        {
            line.SetPosition(0, firePoint.position);
            line.SetPosition(1, firePoint.position + firePoint.right * 100);
        }

        line.enabled = true;
        
        yield return new WaitForSeconds(0.02f);
        
        line.enabled = false;
    }
}
