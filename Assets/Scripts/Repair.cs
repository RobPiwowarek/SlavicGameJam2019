using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public float restorePoints;
    private HashSet<Collider2D> collidingBuildings = new HashSet<Collider2D>();


    // Start is called before the first frame update
    void Start()
    {
    }

    private float DistanceToMe(Vector3 other)
    {
        return (other - gameObject.transform.position).magnitude;
    }

    private Collider2D GetClosestCollidingBuilding()
    {
        float closestDistance = float.PositiveInfinity;
        Collider2D closest = null;

        foreach (Collider2D building in collidingBuildings)
        {
            float distance = DistanceToMe(building.transform.position);
            if (distance < closestDistance)
            {
                closest = building;
                closestDistance = distance;
            }
        }

        return closest;
    }

    private void RepairBuilding(Collider2D other)
    {
        Health otherHealth = other.GetComponent<Health>();
        if (otherHealth)
        {
            Debug.Log("Restoring building health");
            otherHealth.restoreHealth(restorePoints);
        }
        else
        {
            Debug.LogWarning("Cannot repair building without health");
        }
    }

    private void RepairClosestCollidingBuilding()
    {
        Collider2D closest = GetClosestCollidingBuilding();
        if (closest)
        {
            Debug.Log("Healing closest building: " + closest.name);
            RepairBuilding(closest);
        }
        else
        {
            Debug.Log("No building to heal");
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Building"))
        {
            Debug.Log("Adding: " + other.name);
            collidingBuildings.Add(other);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (collidingBuildings.Contains(other))
        {
            Debug.Log("Removing: " + other.name);
            collidingBuildings.Remove(other);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ActionButton2"))
        {
            RepairClosestCollidingBuilding();
        }
    }
}
